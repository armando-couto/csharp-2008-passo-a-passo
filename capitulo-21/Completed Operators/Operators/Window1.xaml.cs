using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Operators
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            ticker.tick += new Tick(tock);
        }

        private void tock()
		{
			time.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
				digital.Hour,
				digital.Minute,
				digital.Second);
		}

		private Ticker ticker = new Ticker();
		private Clock digital = new Clock();
    }
}
