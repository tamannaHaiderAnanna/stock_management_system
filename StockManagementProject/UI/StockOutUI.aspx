<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementProject.UI.StockOutUI" %>

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
            <asp:HyperLink  runat="server" NavigateUrl="ItemSetupUI.aspx">Item Setup</asp:HyperLink>
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
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Stock Out"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Company"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="companyDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Item"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="itemDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label5" runat="server" Text="ReOrder Level"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="reOrderLevelTextBox" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:Label ID="Label23" runat="server" Text="Available Quantity"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="availableQuantityTextBox" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Stock Out Quantity"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="stockOutQuantityTextBox" runat="server"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
            <br />
            <br />
            <asp:GridView ID="stockOutGridView" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" OnSelectedIndexChanged="stockOutGridView_SelectedIndexChanged">
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
                        <asp:Label  runat="server" Text='<%#: Eval("ItemName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                                          <Columns>
                <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label  runat="server" Text='<%#: Eval("CompanyName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                                          <Columns>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label  runat="server" Text='<%#: Eval("StockOutAmount")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="sellButton" runat="server" Text="Sell" OnClick="sellButton_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="damageButton" runat="server" Text="Damage" OnClick="damageButton_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="lostButton" runat="server" OnClick="lostButton_Click" Text="Lost" />
            </fieldset>
    
    </div>
    </form>
</body>
</html>
