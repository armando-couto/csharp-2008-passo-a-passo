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
using System.ComponentModel;
using System.Collections;

namespace Suppliers
{
    public partial class SupplierInfo : Window
    {
        private NorthwindDataContext ndc = null;
        private Supplier supplier = null;
        private BindingList<Product> productsInfo = null;

        public SupplierInfo()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ndc = new NorthwindDataContext();
            this.suppliersList.DataContext = ndc.Suppliers;
        }

        private void suppliersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            supplier = this.suppliersList.SelectedItem as Supplier;
            IList list = ((IListSource)supplier.Products).GetList();
            productsInfo = list as BindingList<Product>;
            this.productsList.DataContext = productsInfo;
        }

        private void productsList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter: editProduct(this.productsList.SelectedItem as Product);
                    break;

                case Key.Insert: addNewProduct();
                    break;

                case Key.Delete: deleteProduct(this.productsList.SelectedItem as Product);
                    break;
            } 
        }

        private void deleteProduct(Product prod)
        {
            MessageBoxResult response = MessageBox.Show("Delete " + prod.ProductName, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (response == MessageBoxResult.Yes)
            {
                supplier.Products.Remove(prod);
                productsInfo.Remove(prod);
                this.saveChanges.IsEnabled = true;
            }
        }

        private void addNewProduct()
        {
            ProductForm pf = new ProductForm();
            pf.Title = "New Product for " + supplier.CompanyName;
            if (pf.ShowDialog().Value)
            {
                Product newProd = new Product();
                newProd.SupplierID = supplier.SupplierID;
                newProd.ProductName = pf.productName.Text;
                newProd.QuantityPerUnit = pf.quantityPerUnit.Text;
                newProd.UnitPrice = Decimal.Parse(pf.unitPrice.Text);
                supplier.Products.Add(newProd);
                productsInfo.Add(newProd);
                this.saveChanges.IsEnabled = true;
            }
        }

        private void editProduct(Product prod)
        {
            ProductForm pf = new ProductForm();
            pf.Title = "Edit Product Details";
            pf.productName.Text = prod.ProductName;
            pf.quantityPerUnit.Text = prod.QuantityPerUnit;
            pf.unitPrice.Text = prod.UnitPrice.ToString();

            if (pf.ShowDialog().Value)
            {
                prod.ProductName = pf.productName.Text;
                prod.QuantityPerUnit = pf.quantityPerUnit.Text;
                prod.UnitPrice = Decimal.Parse(pf.unitPrice.Text);
                this.saveChanges.IsEnabled = true;
            }
        }

        private void saveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ndc.SubmitChanges();
                saveChanges.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving changes");
            }
        }
    }

    [ValueConversion(typeof(string), typeof(decimal?))]
    class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return String.Format("{0:C}", value);
            else
                return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
