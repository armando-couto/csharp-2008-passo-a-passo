using System.Windows.Controls;

namespace Delegates
{
	class Clock
	{
        public Clock(TextBox displayBox)
        {
            this.display = displayBox;
        }

        public void Start()
		{
            pulsed.tick += this.RefreshTime;
        }

		public void Stop()
		{
            pulsed.tick -= this.RefreshTime;
        }

		private void RefreshTime(int hh, int mm, int ss)
		{
			this.display.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss);
		}

		private Ticker pulsed = new Ticker();
        private TextBox display;
    }
}
