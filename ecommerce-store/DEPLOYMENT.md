# Deployment Guide

## 🚀 Deploying EliteStore

This guide covers multiple deployment options for your e-commerce store.

---

## Option 1: Vercel (Recommended)

Vercel is the easiest way to deploy Next.js applications.

### Steps:

1. **Install Vercel CLI** (if not already installed):
```bash
npm install -g vercel
```

2. **Login to Vercel**:
```bash
vercel login
```

3. **Deploy**:
```bash
cd /vercel/sandbox/ecommerce-store
vercel
```

4. **Follow the prompts**:
   - Set up and deploy? Yes
   - Which scope? (Select your account)
   - Link to existing project? No
   - Project name? ecommerce-store
   - Directory? ./
   - Override settings? No

5. **Production Deployment**:
```bash
vercel --prod
```

### Vercel Dashboard:
- Visit https://vercel.com/dashboard
- View your deployed site
- Configure custom domain
- Monitor analytics

---

## Option 2: Netlify

### Steps:

1. **Install Netlify CLI**:
```bash
npm install -g netlify-cli
```

2. **Build the project**:
```bash
cd /vercel/sandbox/ecommerce-store
npm run build
```

3. **Deploy**:
```bash
netlify deploy
```

4. **Production deployment**:
```bash
netlify deploy --prod
```

### Configuration:
Create `netlify.toml`:
```toml
[build]
  command = "npm run build"
  publish = ".next"

[[plugins]]
  package = "@netlify/plugin-nextjs"
```

---

## Option 3: Docker

### Dockerfile:

Create `Dockerfile` in project root:
```dockerfile
FROM node:18-alpine AS base

# Install dependencies
FROM base AS deps
WORKDIR /app
COPY package*.json ./
RUN npm ci

# Build the application
FROM base AS builder
WORKDIR /app
COPY --from=deps /app/node_modules ./node_modules
COPY . .
RUN npm run build

# Production image
FROM base AS runner
WORKDIR /app

ENV NODE_ENV production

RUN addgroup --system --gid 1001 nodejs
RUN adduser --system --uid 1001 nextjs

COPY --from=builder /app/public ./public
COPY --from=builder --chown=nextjs:nodejs /app/.next/standalone ./
COPY --from=builder --chown=nextjs:nodejs /app/.next/static ./.next/static

USER nextjs

EXPOSE 3000

ENV PORT 3000

CMD ["node", "server.js"]
```

### Build and Run:
```bash
docker build -t ecommerce-store .
docker run -p 3000:3000 ecommerce-store
```

---

## Option 4: AWS (EC2)

### Steps:

1. **Launch EC2 Instance**:
   - Ubuntu 22.04 LTS
   - t2.micro or larger
   - Open port 80 and 443

2. **SSH into instance**:
```bash
ssh -i your-key.pem ubuntu@your-ec2-ip
```

3. **Install Node.js**:
```bash
curl -fsSL https://deb.nodesource.com/setup_18.x | sudo -E bash -
sudo apt-get install -y nodejs
```

4. **Install PM2**:
```bash
sudo npm install -g pm2
```

5. **Clone/Upload your project**:
```bash
# Upload files or clone from git
cd /home/ubuntu
# Copy your project here
```

6. **Install dependencies and build**:
```bash
cd ecommerce-store
npm install
npm run build
```

7. **Start with PM2**:
```bash
pm2 start npm --name "ecommerce-store" -- start
pm2 save
pm2 startup
```

8. **Setup Nginx** (optional):
```bash
sudo apt-get install nginx
```

Create `/etc/nginx/sites-available/ecommerce-store`:
```nginx
server {
    listen 80;
    server_name your-domain.com;

    location / {
        proxy_pass http://localhost:3000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection 'upgrade';
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}
```

Enable site:
```bash
sudo ln -s /etc/nginx/sites-available/ecommerce-store /etc/nginx/sites-enabled/
sudo nginx -t
sudo systemctl restart nginx
```

---

## Option 5: DigitalOcean App Platform

### Steps:

1. **Create account** at https://digitalocean.com

2. **Create new app**:
   - Choose GitHub/GitLab repository
   - Or upload code directly

3. **Configure build**:
   - Build Command: `npm run build`
   - Run Command: `npm start`
   - Environment: Node.js

4. **Deploy**:
   - Click "Deploy"
   - Wait for build to complete

---

## Environment Variables

If you add environment variables later, configure them in your deployment platform:

### Example `.env.local`:
```env
NEXT_PUBLIC_SITE_URL=https://your-domain.com
NEXT_PUBLIC_STRIPE_KEY=your_stripe_key
DATABASE_URL=your_database_url
```

### Vercel:
```bash
vercel env add NEXT_PUBLIC_SITE_URL
```

### Netlify:
```bash
netlify env:set NEXT_PUBLIC_SITE_URL "https://your-domain.com"
```

---

## Custom Domain Setup

### Vercel:
1. Go to Project Settings → Domains
2. Add your domain
3. Update DNS records as instructed

### Netlify:
1. Go to Domain Settings
2. Add custom domain
3. Update DNS records

### DNS Records (General):
```
Type: A
Name: @
Value: [Your server IP]

Type: CNAME
Name: www
Value: your-domain.com
```

---

## SSL Certificate

### Vercel/Netlify:
- Automatic SSL (Let's Encrypt)
- No configuration needed

### AWS/DigitalOcean:
Use Certbot:
```bash
sudo apt-get install certbot python3-certbot-nginx
sudo certbot --nginx -d your-domain.com -d www.your-domain.com
```

---

## Performance Optimization

### 1. Enable Caching:
```typescript
// next.config.ts
const nextConfig = {
  images: {
    remotePatterns: [
      {
        protocol: 'https',
        hostname: 'images.unsplash.com',
      },
    ],
  },
  // Add caching headers
  async headers() {
    return [
      {
        source: '/:all*(svg|jpg|png)',
        locale: false,
        headers: [
          {
            key: 'Cache-Control',
            value: 'public, max-age=31536000, immutable',
          }
        ],
      },
    ]
  },
};
```

### 2. Enable Compression:
Already enabled by Next.js

### 3. CDN Setup:
- Vercel: Automatic global CDN
- Netlify: Automatic global CDN
- Others: Use Cloudflare

---

## Monitoring

### Vercel Analytics:
```bash
npm install @vercel/analytics
```

Add to `app/layout.tsx`:
```typescript
import { Analytics } from '@vercel/analytics/react';

export default function RootLayout({ children }) {
  return (
    <html>
      <body>
        {children}
        <Analytics />
      </body>
    </html>
  );
}
```

### Google Analytics:
Add to `app/layout.tsx`:
```typescript
<Script
  src="https://www.googletagmanager.com/gtag/js?id=GA_MEASUREMENT_ID"
  strategy="afterInteractive"
/>
<Script id="google-analytics" strategy="afterInteractive">
  {`
    window.dataLayer = window.dataLayer || [];
    function gtag(){dataLayer.push(arguments);}
    gtag('js', new Date());
    gtag('config', 'GA_MEASUREMENT_ID');
  `}
</Script>
```

---

## Pre-Deployment Checklist

- [ ] Run `npm run build` successfully
- [ ] Test all pages locally
- [ ] Check responsive design
- [ ] Verify all images load
- [ ] Test cart functionality
- [ ] Check all timers work
- [ ] Verify social proof notifications
- [ ] Test checkout flow
- [ ] Update metadata (title, description)
- [ ] Add favicon
- [ ] Configure analytics
- [ ] Set up error tracking
- [ ] Test on multiple browsers
- [ ] Check mobile performance
- [ ] Optimize images
- [ ] Review security headers

---

## Post-Deployment

### 1. Test Production Site:
- [ ] Homepage loads
- [ ] All pages accessible
- [ ] Images display correctly
- [ ] Timers are working
- [ ] Cart persists
- [ ] Forms submit correctly
- [ ] Mobile responsive
- [ ] Fast load times

### 2. SEO Setup:
- Add sitemap.xml
- Add robots.txt
- Submit to Google Search Console
- Set up Google Analytics
- Configure meta tags

### 3. Monitor:
- Check error logs
- Monitor performance
- Track conversions
- Review analytics

---

## Troubleshooting

### Build Fails:
```bash
# Clear cache and rebuild
rm -rf .next node_modules
npm install
npm run build
```

### Images Not Loading:
- Check `next.config.ts` remotePatterns
- Verify image URLs are accessible
- Check CORS settings

### Timers Not Working:
- Verify JavaScript is enabled
- Check browser console for errors
- Ensure client components are marked with 'use client'

### Cart Not Persisting:
- Check localStorage is enabled
- Verify browser allows cookies
- Check for console errors

---

## Scaling

### When to Scale:
- High traffic (>10k visitors/day)
- Slow page loads
- Database bottlenecks

### How to Scale:
1. **Vercel**: Automatic scaling
2. **AWS**: Use Load Balancer + Auto Scaling
3. **Database**: Move to managed service (Supabase, PlanetScale)
4. **CDN**: Use Cloudflare
5. **Caching**: Implement Redis

---

## Backup Strategy

### Code:
- Use Git repository
- Push to GitHub/GitLab
- Regular commits

### Data:
- Export product data regularly
- Backup database (if added)
- Store in multiple locations

---

## Support

For deployment issues:
- Vercel: https://vercel.com/support
- Netlify: https://www.netlify.com/support/
- Next.js: https://nextjs.org/docs

---

**Ready to deploy!** Choose your preferred platform and follow the steps above. 🚀
