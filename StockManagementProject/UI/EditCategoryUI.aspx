<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCategoryUI.aspx.cs" Inherits="StockManagementProject.UI.EditCategoryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Management System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <fieldset>
            
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Agency FB" Font-Size="XX-Large" ForeColor="Maroon" Text="Stock Management System"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Insert Name"></asp:Label>
            :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="categoryUpdateTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" />
            <br />
            <asp:Label ID="outputLabel" runat="server"></asp:Label>
            <br />
            <asp:HyperLink  runat="server" NavigateUrl="CategoryUI.aspx">Back To Category Setup</asp:HyperLink>
            
            </fieldset>
    
    </div>
    </form>
</body>
</html>
