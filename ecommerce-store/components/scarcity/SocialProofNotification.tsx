'use client';

import { useState, useEffect } from 'react';

interface Purchase {
  id: number;
  product: string;
  location: string;
  time: string;
}

const mockPurchases: Purchase[] = [
  { id: 1, product: 'Wireless Headphones', location: 'New York', time: '2 minutes ago' },
  { id: 2, product: 'Smart Watch Pro', location: 'Los Angeles', time: '5 minutes ago' },
  { id: 3, product: 'Laptop Stand', location: 'Chicago', time: '8 minutes ago' },
  { id: 4, product: 'USB-C Hub', location: 'Houston', time: '12 minutes ago' },
  { id: 5, product: 'Mechanical Keyboard', location: 'Phoenix', time: '15 minutes ago' },
  { id: 6, product: 'Wireless Mouse', location: 'Philadelphia', time: '18 minutes ago' },
  { id: 7, product: 'Monitor 27"', location: 'San Antonio', time: '22 minutes ago' },
  { id: 8, product: 'Webcam HD', location: 'San Diego', time: '25 minutes ago' },
];

export default function SocialProofNotification() {
  const [currentPurchase, setCurrentPurchase] = useState<Purchase | null>(null);
  const [isVisible, setIsVisible] = useState(false);

  useEffect(() => {
    const showNotification = () => {
      const randomPurchase = mockPurchases[Math.floor(Math.random() * mockPurchases.length)];
      setCurrentPurchase(randomPurchase);
      setIsVisible(true);

      setTimeout(() => {
        setIsVisible(false);
      }, 5000);
    };

    const initialDelay = setTimeout(() => {
      showNotification();
      const interval = setInterval(showNotification, 15000);
      return () => clearInterval(interval);
    }, 3000);

    return () => clearTimeout(initialDelay);
  }, []);

  if (!currentPurchase || !isVisible) return null;

  return (
    <div className="fixed bottom-6 left-6 z-50 animate-slide-in">
      <div className="bg-white rounded-lg shadow-2xl border border-gray-200 p-4 max-w-sm">
        <div className="flex items-start gap-3">
          <div className="flex-shrink-0">
            <div className="w-12 h-12 bg-gradient-to-br from-green-400 to-green-600 rounded-full flex items-center justify-center">
              <span className="text-white text-xl">✓</span>
            </div>
          </div>
          <div className="flex-1 min-w-0">
            <div className="flex items-center gap-2 mb-1">
              <div className="w-2 h-2 bg-green-500 rounded-full animate-pulse"></div>
              <p className="text-xs font-semibold text-green-600 uppercase tracking-wide">
                Verified Purchase
              </p>
            </div>
            <p className="text-sm font-medium text-gray-900 mb-1">
              Someone in <span className="font-semibold">{currentPurchase.location}</span>
            </p>
            <p className="text-sm text-gray-600 mb-1">
              purchased <span className="font-medium">{currentPurchase.product}</span>
            </p>
            <p className="text-xs text-gray-500">{currentPurchase.time}</p>
          </div>
          <button
            onClick={() => setIsVisible(false)}
            className="flex-shrink-0 text-gray-400 hover:text-gray-600 transition-colors"
            aria-label="Close notification"
          >
            <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M6 18L18 6M6 6l12 12" />
            </svg>
          </button>
        </div>
      </div>
    </div>
  );
}
