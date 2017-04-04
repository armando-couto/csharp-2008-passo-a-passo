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

namespace CustomerDetails
{
    public partial class CustomerForm : Window
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void saveCustomer_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression titleBe = this.title.GetBindingExpression(ComboBox.TextProperty);
            BindingExpression foreNameBe = this.foreName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression lastNameBe = this.lastName.GetBindingExpression(TextBox.TextProperty);
            
            titleBe.UpdateSource();
            foreNameBe.UpdateSource();
            lastNameBe.UpdateSource();
            
            if (titleBe.HasError || foreNameBe.HasError || lastNameBe.HasError )
            {
                MessageBox.Show("Please correct errors", "Not Saved");
            }
            else
            {

                Binding customerBinding = BindingOperations.GetBinding(this.title, ComboBox.TextProperty);
                Customer customer = customerBinding.Source as Customer;
                MessageBox.Show(customer.ToString(), "Saved");
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private Binding rebuildBinding(string parameter)
        {
            Binding customerBinding = BindingOperations.GetBinding(this.title, ComboBox.TextProperty);
            Customer customer = customerBinding.Source as Customer;
            Binding binding = new Binding();
            binding.Source = customer;
            binding.Path = new PropertyPath("Gender");
            binding.Converter = new GenderConverter();
            binding.ConverterParameter = parameter;
            // binding.ValidationRules.Add(new ExceptionValidationRule());
            return binding;
        }

        private void male_Checked(object sender, RoutedEventArgs e)
        {
            Binding binding = rebuildBinding("Female");
            if (this.female != null)
            {
                this.female.SetBinding(RadioButton.IsCheckedProperty, binding);
                BindingExpression femaleBe = this.female.GetBindingExpression(RadioButton.IsCheckedProperty);
                femaleBe.UpdateTarget();
            }
        }

        private void female_Checked(object sender, RoutedEventArgs e)
        {
            Binding binding = rebuildBinding("Male");
            if (this.male != null)
            {
                this.male.SetBinding(RadioButton.IsCheckedProperty, binding);
                BindingExpression maleBe = this.male.GetBindingExpression(RadioButton.IsCheckedProperty);
                maleBe.UpdateTarget();
            }
        }
    }
}
