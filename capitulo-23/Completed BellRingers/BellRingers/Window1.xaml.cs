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
using System.IO;
using Microsoft.Win32;

namespace BellRingers
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string[] towers = { "Great Shevington", "Little Mudford", "Upper Gumtree", "Downley Hatch" };
        private string[] ringingMethods = { "Plain Bob", "Reverse Canterbury", "Grandsire", "Stedman", "Kent Treble Bob", "Old Oxford Delight", "Winchendon Place", "Norwich Surprise", "Crayford Little Court" };

        private ContextMenu windowContextMenu = null;

        public Window1()
        {
            InitializeComponent();
            this.Reset();

            MenuItem saveMemberMenuItem = new MenuItem();
            saveMemberMenuItem.Header = "Save Member Details";
            saveMemberMenuItem.Click += new RoutedEventHandler(saveMember_Click);

            MenuItem clearFormMenuItem = new MenuItem();
            clearFormMenuItem.Header = "Clear Form";
            clearFormMenuItem.Click += new RoutedEventHandler(clear_Click);

            windowContextMenu = new ContextMenu();
            windowContextMenu.Items.Add(saveMemberMenuItem);
            windowContextMenu.Items.Add(clearFormMenuItem);
        }

        public void Reset()
        {
            firstName.Text = String.Empty;
            lastName.Text = String.Empty;

            towerNames.Items.Clear();
            foreach (string towerName in towers)
            {
                towerNames.Items.Add(towerName);
            }
            towerNames.Text = towerNames.Items[0] as string;
            
            methods.Items.Clear();
            CheckBox method;
            foreach (string methodName in ringingMethods)
            {
                method = new CheckBox();
                method.Margin = new Thickness(0, 0, 0, 10);
                method.Content = methodName;
                methods.Items.Add(method);
            }

            isCaptain.IsChecked = false;

            novice.IsChecked = true;

            System.Windows.Forms.DateTimePicker memberDate = hostMemberSince.Child as System.Windows.Forms.DateTimePicker;
            memberDate.Value = DateTime.Today;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            this.Reset();
        }

        //private void add_Click(object sender, RoutedEventArgs e)
        //{
        //    string nameAndTower = String.Format("Member name: {0} {1} from the tower at {2} rings the following methods:", firstName.Text, lastName.Text, towerNames.Text);
        //    StringBuilder details = new StringBuilder();
        //    details.AppendLine(nameAndTower);
        //    foreach (CheckBox cb in methods.Items)
        //    {
        //        if (cb.IsChecked.Value)
        //        {
        //            details.AppendLine(cb.Content.ToString());
        //        }
        //    }
        //    MessageBox.Show(details.ToString(), "Member Information");
        //}

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult key = MessageBox.Show(
                "Are you sure you want to quit",
                "Confirm", 
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);
            e.Cancel = (key == MessageBoxResult.No);
        }

        private void newMember_Click(object sender, RoutedEventArgs e)
        {
            this.Reset();
            saveMember.IsEnabled = true;
            firstName.IsEnabled = true;
            lastName.IsEnabled = true;
            towerNames.IsEnabled = true;
            isCaptain.IsEnabled = true;
            hostMemberSince.IsEnabled = true;
            yearsExperience.IsEnabled = true;
            methods.IsEnabled = true;
            // add.IsEnabled = true;
            clear.IsEnabled = true;

            this.ContextMenu = windowContextMenu;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clearName_Click(object sender, RoutedEventArgs e)
        {
            firstName.Text = String.Empty;
            lastName.Text = String.Empty;
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

        private void saveMember_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "txt";
            saveDialog.AddExtension = true;
            saveDialog.FileName = "Members";
            saveDialog.InitialDirectory = @"C:\Users\Student\Documents\";
            saveDialog.OverwritePrompt = true;
            saveDialog.Title = "Bell Ringers";
            saveDialog.ValidateNames = true;

            if (saveDialog.ShowDialog().Value)
            {
                StreamWriter writer = new StreamWriter(saveDialog.FileName);
                writer.WriteLine("First Name: {0}", firstName.Text);
                writer.WriteLine("Last Name: {0}", lastName.Text);
                writer.WriteLine("Tower: {0}", towerNames.Text);
                writer.WriteLine("Captain: {0}", isCaptain.IsChecked.ToString());
                System.Windows.Forms.DateTimePicker memberDate = hostMemberSince.Child as System.Windows.Forms.DateTimePicker;
                writer.WriteLine("Member Since: {0}", memberDate.Value.ToString());
                writer.WriteLine("Methods: ");
                foreach (CheckBox cb in methods.Items)
                {
                    if (cb.IsChecked.Value)
                    {
                        writer.WriteLine(cb.Content.ToString());
                    }
                }
                writer.Close();

                MessageBox.Show("Member details saved", "Saved");
            }
        }
    }
}
