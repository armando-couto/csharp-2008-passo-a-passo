
namespace Operators
{
	class Clock
	{
		public Clock()
		{
			System.DateTime now = System.DateTime.Now;
			this.hour = new Hour(now.Hour);
			this.minute = new Minute(now.Minute);
			this.second = new Second(now.Second);
			this.pulsed.tick += tock;
		}

		public Clock(Hour hh, Minute mm, Second ss)
		{
			this.hour = hh;
			this.minute = mm;
			this.second = ss;
			this.pulsed.tick += tock;
		}

		public int Hour
		{
			get { return this.hour.Value; }
		}

		public int Minute
		{
			get { return this.minute.Value; }
		}

		public int Second
		{
		   get { return this.second.Value; }
		}

		private void tock()
		{
			this.second++;
			if (this.second == 0)
			{
				this.minute++;
				if (this.minute == 0)
				{
					this.hour++;
				}
			}
		}

		private Ticker pulsed = new Ticker();
		private Hour hour;
		private Minute minute;
		private Second second;
	}
}
