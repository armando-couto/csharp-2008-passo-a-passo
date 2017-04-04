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
using ProductClient.NorthwindServices;

namespace ProductClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
        }

        private void getProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductsServiceClient proxy = new ProductsServiceClient();
            try
            {
                int prodID = Int32.Parse(this.productID.Text);
                ProductInfo product = proxy.GetProductInfo(prodID);
                this.productName.Content = product.ProductName;
                this.supplierID.Content = product.SupplierID;
                this.categoryID.Content = product.CategoryID;
                this.quantityPerUnit.Content = product.QuantityPerUnit;
                this.unitPrice.Content = String.Format("{0:C}", product.UnitPrice);
                this.unitsInStock.Content = product.UnitsInStock;
                this.unitsOnOrder.Content = product.UnitsOnOrder;
                this.reorderLevel.Content = product.ReorderLevel;
                this.discontinued.IsChecked = product.Discontinued;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching product details: " +
                    ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                if (proxy.State == System.ServiceModel.CommunicationState.Faulted)
                    proxy.Abort();
                else
                    proxy.Close();
            }
        }

        private void calcCost_Click(object sender, RoutedEventArgs e)
        {
            ProductsServiceClient proxy = new ProductsServiceClient();
            try
            {
                int prodID = Int32.Parse(this.productID.Text);
                int number = Int32.Parse(this.howMany.Text);
                decimal cost = proxy.HowMuchWillItCost(prodID, number);
                this.totalCost.Content = String.Format("{0:C}", cost);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obtaining cost: " +
                    ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                if (proxy.State == System.ServiceModel.CommunicationState.Faulted)
                    proxy.Abort();
                else
                    proxy.Close();
            }
        }
    }
}
