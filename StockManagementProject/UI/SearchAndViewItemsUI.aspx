<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAndViewItemsUI.aspx.cs" Inherits="StockManagementProject.UI.SearchAndViewItemsUI" %>

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
            <asp:HyperLink  runat="server" NavigateUrl="CategoryUI.aspx">Category Setup</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="CompanySetupUI.aspx">Company Setup</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink runat="server" NavigateUrl="ItemSetupUI.aspx">Item Setup</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="StockInUI.aspx">Stock In</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="StockOutUI.aspx">Stock Out</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="SearchAndViewItemsUI.aspx">Search &amp; View Items</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink  runat="server" NavigateUrl="ViewSalesReport.aspx">View Sales Report</asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Search And View Items' Summary"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Company"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="companyDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Category"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="categoryDropDownList" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
            <br />
            <asp:GridView ID="itemsViewGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                             <span>
     <%#Container.DataItemIndex + 1%>
     </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                <Columns>
                                    <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:Label  runat="server" Text='<%#Eval("ItemName")%>'></asp:Label>
         </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label  runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
         </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label  runat="server" Text='<%#Eval("AvailableQuantity")%>'></asp:Label>
         </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                                                <Columns>
                                    <asp:TemplateField HeaderText="ReOrderLevel">
                    <ItemTemplate>
                        <asp:Label  runat="server" Text='<%#Eval("ReOrderLevel")%>'></asp:Label>
         </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
            </asp:GridView>
            
            </fieldset>
    
    </div>
    </form>
</body>
</html>
