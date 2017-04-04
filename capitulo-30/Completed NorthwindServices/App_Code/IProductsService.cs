using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

[ServiceContract]
public interface IProductsService
{
	[OperationContract]
	decimal HowMuchWillItCost(int productID, int howMany);

	[OperationContract]
	ProductInfo GetProductInfo(int productID);
}


[DataContract]
public class ProductInfo
{
    [DataMember]
    public int ProductID { get; set; }

    [DataMember]
    public string ProductName { get; set; }

    [DataMember]
    public int? SupplierID { get; set; }

    [DataMember]
    public int? CategoryID { get; set; }

    [DataMember]
    public string QuantityPerUnit { get; set; }

    [DataMember]
    public decimal? UnitPrice { get; set; }

    [DataMember]
    public short? UnitsInStock { get; set; }

    [DataMember]
    public short? UnitsOnOrder { get; set; }

    [DataMember]
    public short? ReorderLevel { get; set; }

    [DataMember]
    public bool? Discontinued { get; set; }
}
