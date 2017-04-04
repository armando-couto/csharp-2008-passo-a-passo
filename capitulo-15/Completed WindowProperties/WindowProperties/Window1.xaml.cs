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


namespace WindowProperties
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
            sizeChanged();
        }

        private void sizeChanged()
        {
            width.Text = this.ActualWidth.ToString();
            height.Text = this.ActualHeight.ToString();
        }

        private void window1SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sizeChanged();
        }
    }
}