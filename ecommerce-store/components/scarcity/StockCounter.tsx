'use client';

interface StockCounterProps {
  stock: number;
  variant?: 'default' | 'compact';
}

export default function StockCounter({ stock, variant = 'default' }: StockCounterProps) {
  const getUrgencyLevel = () => {
    if (stock <= 3) return 'critical';
    if (stock <= 10) return 'low';
    if (stock <= 20) return 'medium';
    return 'normal';
  };

  const urgency = getUrgencyLevel();

  const urgencyStyles = {
    critical: 'bg-red-50 border-red-300 text-red-800',
    low: 'bg-orange-50 border-orange-300 text-orange-800',
    medium: 'bg-yellow-50 border-yellow-300 text-yellow-800',
    normal: 'bg-green-50 border-green-300 text-green-800',
  };

  const dotStyles = {
    critical: 'bg-red-500',
    low: 'bg-orange-500',
    medium: 'bg-yellow-500',
    normal: 'bg-green-500',
  };

  if (variant === 'compact') {
    return (
      <div className="flex items-center gap-2">
        <div className={`w-2 h-2 rounded-full ${dotStyles[urgency]} animate-pulse`}></div>
        <span className={`text-sm font-medium ${urgency === 'critical' ? 'text-red-600' : urgency === 'low' ? 'text-orange-600' : 'text-gray-700'}`}>
          {stock <= 10 ? `Only ${stock} left!` : `${stock} in stock`}
        </span>
      </div>
    );
  }

  return (
    <div className={`border rounded-lg p-3 ${urgencyStyles[urgency]}`}>
      <div className="flex items-center gap-2">
        <div className={`w-3 h-3 rounded-full ${dotStyles[urgency]} ${urgency === 'critical' || urgency === 'low' ? 'animate-pulse' : ''}`}></div>
        <div>
          <p className="font-semibold text-sm">
            {urgency === 'critical' && '🔥 Almost Gone!'}
            {urgency === 'low' && '⚠️ Low Stock Alert'}
            {urgency === 'medium' && '📦 Limited Stock'}
            {urgency === 'normal' && '✓ In Stock'}
          </p>
          <p className="text-sm mt-0.5">
            {stock <= 10 ? (
              <>Only <span className="font-bold">{stock}</span> left in stock!</>
            ) : (
              <>{stock} units available</>
            )}
          </p>
        </div>
      </div>
      {urgency === 'critical' && (
        <p className="text-xs mt-2 font-medium">Order now before it's gone!</p>
      )}
    </div>
  );
}
