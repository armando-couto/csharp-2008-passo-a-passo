using System;
using System.Timers;
using System.Windows.Threading;

namespace Operators
{
	public delegate void Tick();

	class Ticker
	{
		public Ticker()
		{
            this.ticking.Tick += new EventHandler(this.OnTimedEvent);
            this.ticking.Interval = new TimeSpan(0, 0, 1); // 1 second
            this.ticking.Start();
		}
	
		public event Tick tick;

		private void OnTimedEvent(object source, EventArgs args)
		{
			if (this.tick != null)
			{
				this.tick();
			}
		}

		private DispatcherTimer ticking = new DispatcherTimer();
	}
}
