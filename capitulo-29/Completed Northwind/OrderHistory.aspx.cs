using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class OrderHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string customerId = Request.QueryString["CustomerID"];
        this.OrderLabel.Text += " " + customerId;
        this.Title += " " + customerId;

        OrderHistoryDataContext context = new OrderHistoryDataContext();
        var orderDetails = context.CustOrderHist(customerId);
        this.OrderGrid.DataSource = orderDetails;

        BoundField productName = this.OrderGrid.Columns[0] as BoundField;
        productName.DataField = "ProductName";
        BoundField total = this.OrderGrid.Columns[1] as BoundField;
        total.DataField = "Total";
        this.OrderGrid.DataBind();
    }
}
