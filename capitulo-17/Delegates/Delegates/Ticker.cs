using System;
using System.Collections;
using System.Timers;
using System.Windows.Threading;

namespace Delegates
{
	class Ticker
	{
        public delegate void Tick(int hh, int mm, int ss);
        
        public Ticker()
		{
            this.ticking.Tick += new EventHandler(this.OnTimedEvent);
            this.ticking.Interval = new TimeSpan(0, 0, 1); // 1 second
            this.ticking.Start();
        }

		public void Add(Tick newMethod)
		{
			this.tickers += newMethod;
		}
		
		public void Remove(Tick oldMethod)
		{
			this.tickers -= oldMethod;
		}

		private void Notify(int hours, int minutes, int seconds)
		{
            if (this.tickers != null)
                this.tickers(hours, minutes, seconds);
        }
	
		private void OnTimedEvent(object source, EventArgs args)
		{
            DateTime now = DateTime.Now;
            int hh = now.Hour;
            int mm = now.Minute;
            int ss = now.Second;
            Notify(hh, mm, ss);
		}

        private Tick tickers;
        private DispatcherTimer ticking = new DispatcherTimer();
	}
}
