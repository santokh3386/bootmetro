# Quick Start Guide

## Running the Application

Since you requested not to start the server, here are the commands to run when you're ready:

### Development Mode
```bash
cd /vercel/sandbox/ecommerce-store
npm run dev
```

Then open http://localhost:3000 in your browser.

### Production Build
```bash
cd /vercel/sandbox/ecommerce-store
npm run build
npm start
```

## Testing the Features

### 1. Homepage
- View the flash sale countdown timer in the header
- See featured products with scarcity elements
- Notice the social proof notifications appearing in the bottom-left

### 2. Products Page
- Filter products by category
- Sort by price or rating
- See stock counters on each product card
- Notice the discount badges on sale items

### 3. Product Detail Page
- View the countdown timer for limited-time offers
- See the stock counter with urgency levels
- Add products to cart with quantity selector
- View trust badges at the bottom
- Check out related products

### 4. Shopping Cart
- See the 15-minute cart reservation timer
- Update quantities or remove items
- View free shipping threshold indicator
- See price breakdown (subtotal, shipping, tax)

### 5. Checkout
- Fill out shipping information
- Enter payment details (demo mode)
- Review order summary
- Complete purchase

## Key Features to Test

✅ **Countdown Timers**: Watch them update every second
✅ **Stock Counters**: Different colors based on stock levels
✅ **Social Proof**: Notifications appear every 15 seconds
✅ **Cart Functionality**: Add, update, remove items
✅ **Responsive Design**: Resize browser to test mobile view
✅ **Navigation**: All links work correctly
✅ **Trust Badges**: Visible on product and checkout pages

## Browser Testing Checklist

- [ ] Homepage loads correctly
- [ ] Product listing shows all products
- [ ] Product detail page displays correctly
- [ ] Add to cart functionality works
- [ ] Cart page shows correct totals
- [ ] Checkout form is functional
- [ ] All timers are counting down
- [ ] Social proof notifications appear
- [ ] Stock counters show correct urgency
- [ ] Trust badges are visible
- [ ] Responsive design works on mobile
- [ ] Navigation between pages works

## Notes

- The application uses localStorage to persist cart data
- All product images are loaded from Unsplash
- Checkout is in demo mode (no real payment processing)
- Timers are set to 6 hours for flash sales and 15 minutes for cart reservation
- Social proof notifications rotate through 8 mock purchases

Enjoy testing your new e-commerce store! 🚀
