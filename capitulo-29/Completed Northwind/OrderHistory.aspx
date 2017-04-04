<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderHistory.aspx.cs" Inherits="OrderHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Northwind Traders - Orders for: </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <asp:Label ID="OrderLabel" runat="server" 
            Font-Names="Arial Black" Font-Size="X-Large" Text="Order History for: "></asp:Label>
      <br />
      <br />
      <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CustomerData.aspx" Text="Return to Customers"></asp:HyperLink>  
      <br />
      <br />
      <asp:GridView ID="OrderGrid" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <RowStyle BackColor="#EFF3FB" />
          <columns>
              <asp:boundfield HeaderText="Product Name"></asp:boundfield>
              <asp:boundfield DataFormatString="{0:N0}" HeaderText="Total">
              <itemstyle horizontalalign="Right" />
              </asp:boundfield>
          </columns>
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
