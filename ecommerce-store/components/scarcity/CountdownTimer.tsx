'use client';

import { useState, useEffect } from 'react';

interface CountdownTimerProps {
  endTime: Date;
  variant?: 'header' | 'product' | 'cart';
  onExpire?: () => void;
}

export default function CountdownTimer({ endTime, variant = 'product', onExpire }: CountdownTimerProps) {
  const [timeLeft, setTimeLeft] = useState({
    hours: 0,
    minutes: 0,
    seconds: 0,
  });
  const [isExpired, setIsExpired] = useState(false);

  useEffect(() => {
    const calculateTimeLeft = () => {
      const difference = endTime.getTime() - new Date().getTime();

      if (difference <= 0) {
        setIsExpired(true);
        if (onExpire) onExpire();
        return { hours: 0, minutes: 0, seconds: 0 };
      }

      return {
        hours: Math.floor((difference / (1000 * 60 * 60)) % 24),
        minutes: Math.floor((difference / 1000 / 60) % 60),
        seconds: Math.floor((difference / 1000) % 60),
      };
    };

    setTimeLeft(calculateTimeLeft());

    const timer = setInterval(() => {
      setTimeLeft(calculateTimeLeft());
    }, 1000);

    return () => clearInterval(timer);
  }, [endTime, onExpire]);

  if (isExpired) return null;

  const formatNumber = (num: number) => num.toString().padStart(2, '0');

  if (variant === 'header') {
    return (
      <div className="bg-gradient-to-r from-red-600 to-orange-600 text-white py-3 px-4 text-center">
        <div className="max-w-7xl mx-auto flex items-center justify-center gap-4 flex-wrap">
          <span className="font-semibold text-sm md:text-base">⚡ FLASH SALE ENDS IN:</span>
          <div className="flex gap-2">
            <TimeUnit value={formatNumber(timeLeft.hours)} label="Hours" />
            <span className="text-xl font-bold">:</span>
            <TimeUnit value={formatNumber(timeLeft.minutes)} label="Min" />
            <span className="text-xl font-bold">:</span>
            <TimeUnit value={formatNumber(timeLeft.seconds)} label="Sec" />
          </div>
        </div>
      </div>
    );
  }

  if (variant === 'cart') {
    return (
      <div className="bg-orange-50 border border-orange-200 rounded-lg p-4 mb-4">
        <div className="flex items-center justify-between">
          <div className="flex items-center gap-2">
            <span className="text-2xl">⏰</span>
            <div>
              <p className="font-semibold text-gray-900">Complete your order soon!</p>
              <p className="text-sm text-gray-600">Your cart is reserved for:</p>
            </div>
          </div>
          <div className="flex gap-1 text-center">
            <div className="bg-white rounded px-2 py-1 min-w-[40px]">
              <div className="text-xl font-bold text-orange-600">{formatNumber(timeLeft.minutes)}</div>
              <div className="text-xs text-gray-500">MIN</div>
            </div>
            <div className="text-xl font-bold text-orange-600 px-1">:</div>
            <div className="bg-white rounded px-2 py-1 min-w-[40px]">
              <div className="text-xl font-bold text-orange-600">{formatNumber(timeLeft.seconds)}</div>
              <div className="text-xs text-gray-500">SEC</div>
            </div>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className="bg-red-50 border border-red-200 rounded-lg p-4 mb-4">
      <div className="flex items-center gap-3">
        <span className="text-2xl">🔥</span>
        <div className="flex-1">
          <p className="font-semibold text-gray-900 mb-1">Limited Time Offer!</p>
          <div className="flex gap-2">
            <div className="bg-red-600 text-white rounded px-3 py-1 text-center min-w-[50px]">
              <div className="text-lg font-bold">{formatNumber(timeLeft.hours)}</div>
              <div className="text-xs">Hours</div>
            </div>
            <div className="bg-red-600 text-white rounded px-3 py-1 text-center min-w-[50px]">
              <div className="text-lg font-bold">{formatNumber(timeLeft.minutes)}</div>
              <div className="text-xs">Min</div>
            </div>
            <div className="bg-red-600 text-white rounded px-3 py-1 text-center min-w-[50px]">
              <div className="text-lg font-bold">{formatNumber(timeLeft.seconds)}</div>
              <div className="text-xs">Sec</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

function TimeUnit({ value, label }: { value: string; label: string }) {
  return (
    <div className="text-center">
      <div className="bg-white bg-opacity-20 rounded px-2 py-1 min-w-[45px]">
        <div className="text-xl md:text-2xl font-bold">{value}</div>
      </div>
      <div className="text-xs mt-1">{label}</div>
    </div>
  );
}
