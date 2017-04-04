using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

public class ProductsService : IProductsService
{
    public decimal HowMuchWillItCost(int productID, int howMany)
    {
        ProductDataContext pdc = new ProductDataContext();
        decimal? cost = pdc.Products.Single(
            p => p.ProductID == productID).UnitPrice;
        
        decimal totalCost = 0;
        if (cost.HasValue)
        {
            totalCost = cost.Value * howMany;
        }

        return totalCost;
    }

    public ProductInfo GetProductInfo(int productID)
    {
        ProductDataContext pdc = new ProductDataContext();
        Product product = pdc.Products.Single(p => p.ProductID == productID);

        ProductInfo prodInfo = null;
        if (product != null)
        {
            prodInfo = new ProductInfo();
            prodInfo.CategoryID = product.CategoryID;
            prodInfo.Discontinued = product.Discontinued;
            prodInfo.ProductID = product.ProductID;
            prodInfo.ProductName = product.ProductName;
            prodInfo.QuantityPerUnit = product.QuantityPerUnit;
            prodInfo.ReorderLevel = product.ReorderLevel;
            prodInfo.SupplierID = product.SupplierID;
            prodInfo.UnitPrice = product.UnitPrice;
            prodInfo.UnitsInStock = product.UnitsInStock;
            prodInfo.UnitsOnOrder = product.UnitsOnOrder;
        }

        return prodInfo;
    }
}
