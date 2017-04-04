<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CustomerData.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Northwind Traders - Customers</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:GridView ID="CustomerGrid" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CustomerID" 
        DataSourceID="CustomerInfoSource" ForeColor="#333333" GridLines="None" 
        PageSize="8" Caption="Northwind Traders Customers" AllowPaging="True">
        <pagersettings mode="NumericFirstLast" pagebuttoncount="5" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <columns>
            <asp:commandfield ShowEditButton="True" EditText="Modify" ButtonType="Button"></asp:commandfield>
            <asp:HyperLinkField DataTextField="CustomerID" HeaderText="Customer ID" Target="_self" DataNavigateUrlFields="CustomerID"
                DataNavigateUrlFormatString="~\OrderHistory.aspx?CustomerID={0}" SortExpression="CustomerID"></asp:HyperLinkField>
            <asp:boundfield DataField="CompanyName" HeaderText="Company" 
                SortExpression="CompanyName"></asp:boundfield>
            <asp:boundfield DataField="ContactName" HeaderText="Contact" 
                SortExpression="ContactName"></asp:boundfield>
            <asp:boundfield DataField="ContactTitle" HeaderText="Title" 
                SortExpression="ContactTitle"></asp:boundfield>
            <asp:boundfield DataField="Address" HeaderText="Address" 
                SortExpression="Address"></asp:boundfield>
            <asp:boundfield DataField="City" HeaderText="City" SortExpression="City">
            </asp:boundfield>
            <asp:boundfield DataField="Region" HeaderText="Region" SortExpression="Region">
            </asp:boundfield>
            <asp:boundfield DataField="PostalCode" HeaderText="Postal Code" 
                SortExpression="PostalCode"></asp:boundfield>
            <asp:boundfield DataField="Country" HeaderText="Country" 
                SortExpression="Country"></asp:boundfield>
            <asp:boundfield DataField="Phone" HeaderText="Phone" SortExpression="Phone">
            </asp:boundfield>
            <asp:boundfield DataField="Fax" HeaderText="Fax" SortExpression="Fax">
            </asp:boundfield>
        </columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:LinqDataSource ID="CustomerInfoSource" runat="server" 
        ContextTypeName="CustomerDataContext" EnableUpdate="True" 
        TableName="Customers">
    </asp:LinqDataSource>
    </form>
</body>
</html>
