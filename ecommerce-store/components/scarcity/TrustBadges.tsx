export default function TrustBadges() {
  const badges = [
    { text: 'Secure Payment', icon: '🔒' },
    { text: 'Free Shipping', icon: '🚚' },
    { text: '30-Day Returns', icon: '↩️' },
    { text: 'Money Back Guarantee', icon: '💰' },
  ];

  return (
    <div className="border-t border-gray-200 pt-4 mt-4">
      <div className="grid grid-cols-2 md:grid-cols-4 gap-3">
        {badges.map((badge, index) => (
          <div
            key={index}
            className="flex flex-col items-center text-center p-3 bg-gray-50 rounded-lg hover:bg-gray-100 transition-colors"
          >
            <span className="text-2xl mb-1">{badge.icon}</span>
            <span className="text-xs font-medium text-gray-700">{badge.text}</span>
          </div>
        ))}
      </div>
      <div className="mt-4 flex items-center justify-center gap-4 flex-wrap">
        <div className="flex items-center gap-2 text-sm text-gray-600">
          <div className="w-8 h-8 bg-blue-100 rounded flex items-center justify-center">
            <span className="text-blue-600 font-bold text-xs">V</span>
          </div>
          <span className="font-medium">Visa</span>
        </div>
        <div className="flex items-center gap-2 text-sm text-gray-600">
          <div className="w-8 h-8 bg-orange-100 rounded flex items-center justify-center">
            <span className="text-orange-600 font-bold text-xs">MC</span>
          </div>
          <span className="font-medium">Mastercard</span>
        </div>
        <div className="flex items-center gap-2 text-sm text-gray-600">
          <div className="w-8 h-8 bg-blue-100 rounded flex items-center justify-center">
            <span className="text-blue-600 font-bold text-xs">AE</span>
          </div>
          <span className="font-medium">Amex</span>
        </div>
        <div className="flex items-center gap-2 text-sm text-gray-600">
          <div className="w-8 h-8 bg-indigo-100 rounded flex items-center justify-center">
            <span className="text-indigo-600 font-bold text-xs">PP</span>
          </div>
          <span className="font-medium">PayPal</span>
        </div>
      </div>
    </div>
  );
}
