using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;



namespace Selection
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        private DateTimePicker first;
        private DateTimePicker second;

        public Window1()
        {
            InitializeComponent();
            first = hostFirst.Child as DateTimePicker;
            second = hostSecond.Child as DateTimePicker;
        }

        private void quitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void compareClick(object sender, RoutedEventArgs e)
        {
            int diff = dateCompare(first.Value, second.Value);
            info.Text = "";
            show("first == second", diff == 0);
            show("first != second", diff != 0);
            show("first <  second", diff < 0);
            show("first <= second", diff <= 0);
            show("first >  second", diff > 0);
            show("first >= second", diff >= 0);
        }

        private void show(string exp, bool result)
        {
            info.Text += exp;
            info.Text += " : " + result.ToString();
            info.Text += "\r\n";
        }

        private int dateCompare(DateTime leftHandSide, DateTime rightHandSide)
        {
            int result;

            if (leftHandSide.Year < rightHandSide.Year)
                result = -1;
            else if (leftHandSide.Year > rightHandSide.Year)
                result = +1;
            else if (leftHandSide.Month < rightHandSide.Month)
                result = -1;
            else if (leftHandSide.Month > rightHandSide.Month)
                result = +1;
            else if (leftHandSide.Day < rightHandSide.Day)
                result = -1;
            else if (leftHandSide.Day > rightHandSide.Day)
                result = +1;
            else
                result = 0;

            return result;
        }
    }
}