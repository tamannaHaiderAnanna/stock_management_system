<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="StockManagementProject.IndexUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Management System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <fieldset>
            <asp:Label ID="Label1" runat="server" BackColor="White" Font-Bold="True" Font-Names="Agency FB" Font-Size="XX-Large" Font-Strikeout="False" ForeColor="Maroon" Text="Stock Management System"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink  runat="server" NavigateUrl="CategoryUI.aspx">Category Setup</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="CompanySetupUI.aspx">Company Setup</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="ItemSetupUI.aspx">Item Setup</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="StockInUI.aspx">Stock In</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="StockOutUI.aspx">Stock Out</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="SearchAndViewItemsUI.aspx">Search &amp; View Items</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="ViewSalesReport.aspx">View Sales Report</asp:HyperLink>
            </fieldset>
    
    </div>
    </form>
</body>
</html>
