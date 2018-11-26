<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryUI.aspx.cs" Inherits="StockManagementProject.UI.CategoryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Management System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center"  >
    <fieldset aria-autocomplete="none"  >
        
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Agency FB" Font-Size="XX-Large" ForeColor="#993300" Text="Stock Management System"></asp:Label>
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
        
        <asp:Label ID="Label1" runat="server" Text="Category Setup" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
        :&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="categoryNameTextBox" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
        <br />
        <asp:Label ID="outputLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="categoryGridView" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" style="margin-right: 0px" AutoGenerateColumns="False" Width="244px">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
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
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label  runat="server" Text='<%#Eval("CategoryName")%>'></asp:Label>   
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>

                        <Columns>
                <asp:TemplateField HeaderText="Action">            
                    <ItemTemplate>
                        <asp:LinkButton ID="updateLinkButton" runat="server" OnClick="updateLinkButton_Click">Update</asp:LinkButton>
                          <asp:HiddenField ID="idHiddenfield" runat="server" Value='<%#Eval("Id")%>' />   
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
        </asp:GridView>
        <br />
        <br />
        
        </fieldset>
    </div>
    </form>
</body>
</html>
