<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="EmployeeForm.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Information</title>
    <style type="text/css">
        .employeeFormStyle
        {
            font-family: Arial;
            color: #0000FF;
            background-image: url('computer.bmp');
            height: 500px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <div class="employeeFormStyle">
    
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial Black" 
            Font-Size="X-Large" Height="36px" Text="Litware, Inc. Software Developers" 
            Width="630px" Style="position: absolute; left: 96px; top: 24px"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="First Name" Style="position: absolute; left: 62px; top: 104px"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Last Name" Style="position: absolute; left: 414px; top: 104px"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Employee Id" Style="position: absolute; left: 62px; top: 168px"></asp:Label>
        <asp:TextBox ID="firstName" runat="server" Height="24px" Width="230px" Style="position: absolute; left: 166px; top: 102px"></asp:TextBox>
        <asp:TextBox ID="lastName" runat="server" Height="24px" Width="230px" Style="position: absolute; left: 508px; top: 102px"></asp:TextBox>
        <asp:TextBox ID="employeeID" runat="server" Height="24px" Width="230px" Style="position: absolute; left: 166px; top: 166px"></asp:TextBox>
    
        <asp:Label ID="Label5" runat="server" Text="Position" Style="position: absolute; left: 86px; top: 224px"></asp:Label>
        <asp:RadioButton ID="workerButton" runat="server" Checked="True" 
            GroupName="positionGroup" Text="Worker" TextAlign="Left" 
            Style="position: absolute; left: 192px; top: 224px" AutoPostBack="True" 
            oncheckedchanged="workerButton_CheckedChanged"/>
        <asp:RadioButton ID="bossButton" runat="server" GroupName="positionGroup" 
            Text="Boss" TextAlign="Left" 
            Style="position: absolute; left: 206px; top: 260px" AutoPostBack="True" 
            oncheckedchanged="bossButton_CheckedChanged"/>
        <asp:RadioButton ID="presidentButton" runat="server" GroupName="positionGroup" 
            Text="President" TextAlign="Left" 
            Style="position: absolute; left: 174px; top: 332px" AutoPostBack="True" 
            oncheckedchanged="presidentButton_CheckedChanged"/>
        <asp:RadioButton ID="vpButton" runat="server" GroupName="positionGroup" 
            Text="Vice President" TextAlign="Left" 
            Style="position: absolute; left: 138px; top: 296px" AutoPostBack="True" 
            oncheckedchanged="vpButton_CheckedChanged"/>
    
        <asp:Label ID="Label6" runat="server" Text="Role" Style="position: absolute; left: 456px; top: 224px"></asp:Label>
        <asp:DropDownList ID="positionRole" runat="server" Width="230px" Style="position: absolute; left: 512px; top: 224px">
        </asp:DropDownList>
    
        <asp:Button ID="saveButton" runat="server" Text="Save" Width="75px"
            Style="position: absolute; left: 328px; top: 408px" 
            onclick="saveButton_Click"/>
        <asp:Button ID="clearButton" runat="server" Text="Clear" Width="75px"
            Style="position: absolute; left: 424px; top: 408px" 
            onclick="clearButton_Click"/>
        <asp:Label ID="infoLabel" runat="server" Height="48px" Width="680px" Style="position: absolute; left: 62px; top: 454px"></asp:Label>
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="You must specify a first name for the employee" 
            Style="position: absolute; left: 400px; top: 106px" 
            ControlToValidate="firstName">*</asp:RequiredFieldValidator>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            Style="position: absolute; left: 744px; top: 106px" runat="server" 
            ErrorMessage="You must specify a last name for the employee" 
            ControlToValidate="lastName" Text="*"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            Style="position: absolute; left: 400px; top: 172px"
            ErrorMessage="You must specify an employee ID" 
            ControlToValidate="employeeID" Text="*"></asp:RequiredFieldValidator>
    
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ErrorMessage="The employee ID must be between 1 and 5000" 
            Style="position: absolute; left: 400x; top: 172px" 
            ControlToValidate="employeeID" MaximumValue="5000" MinimumValue="1" 
            Type="Integer">*</asp:RangeValidator>
    
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            Style="position: absolute; left: 300px; top: 260px" />
    
    </div>
    </form>
</body>
</html>
