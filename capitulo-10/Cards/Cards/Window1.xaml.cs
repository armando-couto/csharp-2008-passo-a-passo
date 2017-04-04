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
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Cards
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void dealClick(object sender, RoutedEventArgs e)
        {
            pack.Shuffle();
            Dealer.Deal(pack, game);
            doRefresh();
        }

        private void returnToPackClick(object sender, RoutedEventArgs e)
        {
            game.ReturnHandsTo(pack);
            doRefresh();
        }

        private void doRefresh()
        {
            north.Text = game.North().ToString();
            south.Text = game.South().ToString();
            west.Text = game.West().ToString();
            east.Text = game.East().ToString();
        }

        private void shuffleClick(object sender, RoutedEventArgs e)
        {
            pack.Shuffle();
        }

        private Pack pack = new Pack();
        private Game game = new Game();
    }
}
