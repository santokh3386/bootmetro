# Scarcity & FOMO Elements Guide

This guide explains each scarcity element, where to find it, and how it works.

## 1. 🔥 Countdown Timer Bar (Header)

**Location**: Top of every page (sticky header)

**Appearance**:
```
┌─────────────────────────────────────────────────────────┐
│  ⚡ FLASH SALE ENDS IN:  05 : 23 : 47                  │
│                         Hours Min  Sec                   │
└─────────────────────────────────────────────────────────┘
```

**Features**:
- Red-to-orange gradient background
- White text for high contrast
- Updates every second
- Visible site-wide
- Sticky positioning

**Purpose**: Create urgency for flash sales

**Code Location**: `components/scarcity/CountdownTimer.tsx` (variant="header")

---

## 2. 📊 Stock Counter

**Location**: Product cards and product detail pages

**Appearance**:

### Critical Stock (≤3 items)
```
┌─────────────────────────────────────┐
│ 🔥 Almost Gone!                     │
│ Only 3 left in stock!               │
│ Order now before it's gone!         │
└─────────────────────────────────────┘
Red background, pulsing dot
```

### Low Stock (≤10 items)
```
┌─────────────────────────────────────┐
│ ⚠️ Low Stock Alert                  │
│ Only 8 left in stock!               │
└─────────────────────────────────────┘
Orange background, pulsing dot
```

### Medium Stock (≤20 items)
```
┌─────────────────────────────────────┐
│ 📦 Limited Stock                    │
│ 15 units available                  │
└─────────────────────────────────────┘
Yellow background
```

### Normal Stock (>20 items)
```
┌─────────────────────────────────────┐
│ ✓ In Stock                          │
│ 25 units available                  │
└─────────────────────────────────────┘
Green background
```

**Compact Variant** (on product cards):
```
● Only 5 left!
```

**Purpose**: Show limited availability and create urgency

**Code Location**: `components/scarcity/StockCounter.tsx`

---

## 3. 👥 Social Proof Notifications

**Location**: Bottom-left corner of screen (site-wide)

**Appearance**:
```
┌─────────────────────────────────────────┐
│  ✓   ● Verified Purchase                │
│ [✓]  Someone in New York                │
│      purchased Wireless Headphones      │
│      2 minutes ago                   ✕  │
└─────────────────────────────────────────┘
```

**Features**:
- Green checkmark icon
- Pulsing green dot
- Location-based messaging
- Time stamp
- Dismissible (X button)
- Slides in from left
- Auto-rotates every 15 seconds

**Mock Purchases**:
1. Wireless Headphones - New York
2. Smart Watch Pro - Los Angeles
3. Laptop Stand - Chicago
4. USB-C Hub - Houston
5. Mechanical Keyboard - Phoenix
6. Wireless Mouse - Philadelphia
7. Monitor 27" - San Antonio
8. Webcam HD - San Diego

**Purpose**: Build trust through social proof

**Code Location**: `components/scarcity/SocialProofNotification.tsx`

---

## 4. ⏰ Product Page Countdown Timer

**Location**: Product detail pages

**Appearance**:
```
┌─────────────────────────────────────────┐
│ 🔥  Limited Time Offer!                 │
│                                          │
│  [05]    [23]    [47]                   │
│  Hours   Min     Sec                    │
└─────────────────────────────────────────┘
Red background with white text boxes
```

**Features**:
- Fire emoji for urgency
- Large, easy-to-read numbers
- Red background
- Updates every second
- Positioned above stock counter

**Purpose**: Create urgency for product-specific offers

**Code Location**: `components/scarcity/CountdownTimer.tsx` (variant="product")

---

## 5. 🛒 Cart Countdown Timer

**Location**: Shopping cart page

**Appearance**:
```
┌─────────────────────────────────────────────────────┐
│ ⏰  Complete your order soon!                       │
│     Your cart is reserved for:          14 : 32    │
│                                          MIN   SEC  │
└─────────────────────────────────────────────────────┘
Orange background
```

**Features**:
- Clock emoji
- 15-minute countdown
- Orange background (less aggressive than red)
- Large minute/second display
- Encourages quick checkout

**Purpose**: Reduce cart abandonment

**Code Location**: `components/scarcity/CountdownTimer.tsx` (variant="cart")

---

## 6. 🔒 Trust Badges

**Location**: Product detail page (below add to cart) and checkout

**Appearance**:
```
┌─────────────────────────────────────────────────────┐
│  [🔒]        [🚚]         [↩️]        [💰]         │
│  Secure      Free         30-Day      Money Back    │
│  Payment     Shipping     Returns     Guarantee     │
├─────────────────────────────────────────────────────┤
│  [V]  Visa   [MC] Mastercard   [AE] Amex   [PP] PayPal │
└─────────────────────────────────────────────────────┘
```

**Features**:
- 4 trust indicators with emojis
- 4 payment method logos
- Grid layout (2x2 on mobile, 4x1 on desktop)
- Gray background on hover
- Professional appearance

**Purpose**: Build trust and reduce purchase anxiety

**Code Location**: `components/scarcity/TrustBadges.tsx`

---

## 7. 💰 Discount Badges

**Location**: Product cards and product detail pages

**Appearance**:
```
Product Image
┌─────────────┐
│ -33%        │  ← Red badge, top-left
│             │
│             │
│         🔥  │  ← Hot badge, top-right (if low stock)
└─────────────┘
```

**Features**:
- Red circular badge
- White text
- Percentage calculation
- Positioned on product image
- "HOT" badge for items with ≤5 stock

**Purpose**: Highlight savings and deals

**Code Location**: `components/product/ProductCard.tsx`

---

## 8. 🚚 Free Shipping Indicator

**Location**: Shopping cart page

**Appearance**:

### When shipping is free:
```
Shipping: FREE ✓
```

### When below threshold:
```
┌─────────────────────────────────────────┐
│ Add $23.45 more for FREE shipping!      │
└─────────────────────────────────────────┘
Blue background
```

**Features**:
- $50 threshold
- Dynamic calculation
- Blue highlight box
- Green "FREE" text when achieved

**Purpose**: Increase average order value

**Code Location**: `app/cart/page.tsx`

---

## 9. 💾 Savings Display

**Location**: Product detail page

**Appearance**:
```
$199.99  $299.99
         ────────
         (crossed out)

You save $100.00 (33% off)
```

**Features**:
- Large current price
- Strikethrough original price
- Green savings text
- Percentage calculation

**Purpose**: Emphasize value and savings

**Code Location**: `app/products/[id]/page.tsx`

---

## 10. ⭐ Ratings & Reviews

**Location**: Product cards and product detail pages

**Appearance**:
```
★★★★★ 4.8 (1,247 reviews)
```

**Features**:
- Yellow stars
- Numeric rating
- Review count
- Social proof element

**Purpose**: Build trust through user feedback

**Code Location**: `components/product/ProductCard.tsx`

---

## Testing Each Element

### Homepage
- ✅ Header countdown timer (top)
- ✅ Social proof notifications (bottom-left)
- ✅ Product cards with stock counters
- ✅ Discount badges on products

### Products Page
- ✅ Header countdown timer
- ✅ Social proof notifications
- ✅ Stock counters on all products
- ✅ Discount badges
- ✅ Ratings and reviews

### Product Detail Page
- ✅ Header countdown timer
- ✅ Product countdown timer
- ✅ Stock counter (full version)
- ✅ Social proof notifications
- ✅ Trust badges
- ✅ Savings display
- ✅ Discount badge on image

### Cart Page
- ✅ Header countdown timer
- ✅ Cart countdown timer (15 min)
- ✅ Social proof notifications
- ✅ Free shipping indicator
- ✅ Price breakdown

### Checkout Page
- ✅ Header countdown timer
- ✅ Social proof notifications
- ✅ Order summary

---

## Customization Tips

### Change Timer Duration
```typescript
// 6 hours
const saleEndTime = new Date(Date.now() + 6 * 60 * 60 * 1000);

// 24 hours
const saleEndTime = new Date(Date.now() + 24 * 60 * 60 * 1000);

// 1 hour
const saleEndTime = new Date(Date.now() + 60 * 60 * 1000);
```

### Adjust Stock Thresholds
```typescript
// In StockCounter.tsx
if (stock <= 3) return 'critical';  // Change to 5
if (stock <= 10) return 'low';      // Change to 15
if (stock <= 20) return 'medium';   // Change to 30
```

### Modify Social Proof Timing
```typescript
// In SocialProofNotification.tsx
setTimeout(() => {
  setIsVisible(false);
}, 5000);  // Change display duration (5 seconds)

const interval = setInterval(showNotification, 15000);  // Change rotation (15 seconds)
```

### Change Free Shipping Threshold
```typescript
// In cart/page.tsx and checkout/page.tsx
const shipping = totalPrice > 50 ? 0 : 9.99;  // Change 50 to desired amount
```

---

## Best Practices

1. **Don't Overdo It**: Use scarcity elements strategically
2. **Be Honest**: Only show real stock levels
3. **Test Timings**: Adjust countdown durations based on your sales cycle
4. **Monitor Performance**: Track which elements drive conversions
5. **Mobile First**: Ensure all elements work on small screens
6. **Accessibility**: Maintain good contrast and readability

---

## Color Psychology

- **Red**: Urgency, danger, immediate action
- **Orange**: Warning, limited time, act soon
- **Yellow**: Caution, limited availability
- **Green**: Success, available, positive
- **Blue**: Trust, security, information

---

All scarcity elements are fully functional and ready to use! 🚀
