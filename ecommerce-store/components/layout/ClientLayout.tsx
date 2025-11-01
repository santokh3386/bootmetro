'use client';

import { ReactNode } from 'react';
import Header from './Header';
import Footer from './Footer';
import CountdownTimer from '../scarcity/CountdownTimer';
import SocialProofNotification from '../scarcity/SocialProofNotification';

const saleEndTime = new Date(Date.now() + 6 * 60 * 60 * 1000);

export default function ClientLayout({ children }: { children: ReactNode }) {
  return (
    <>
      <CountdownTimer endTime={saleEndTime} variant="header" />
      <Header />
      <main className="min-h-screen">
        {children}
      </main>
      <Footer />
      <SocialProofNotification />
    </>
  );
}
