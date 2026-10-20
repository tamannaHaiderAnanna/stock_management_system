using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProject.BLL;
using StockManagementProject.DAL.Models;
using StockManagementProject.DAL.Models.ViewModels;
using StockManagementProject.Utility;

namespace StockManagementProject.UI
{    [Serializable]
    public partial class StockOutUI : System.Web.UI.Page
    {
        StockOutManager aStockOutManager = new StockOutManager();
        
        ItemsViewModelManager anItemsViewModelManager = new ItemsViewModelManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = anItemsViewModelManager.GetCompanies();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Add(ConstantMessage.selectMessage);
                companyDropDownList.SelectedValue = ConstantMessage.selectMessage;
                itemDropDownList.Items.Add(ConstantMessage.selectMessage);
                itemDropDownList.SelectedValue = ConstantMessage.selectMessage;
                List<StockOut> allStockOuts = new List<StockOut>();
                ViewState["ListVS"] = allStockOuts;
            }
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedValue != ConstantMessage.selectMessage)
            {
                itemDropDownList.DataSource =
                    anItemsViewModelManager.GetAllItemsViewByCompany(Convert.ToInt32(companyDropDownList.SelectedValue));
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataValueField = "Id";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Add(ConstantMessage.selectMessage);
                itemDropDownList.SelectedValue = ConstantMessage.selectMessage;
            }
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedValue != ConstantMessage.selectMessage &&
    itemDropDownList.SelectedValue != ConstantMessage.selectMessage)
            {
                ItemsViewModels anItemsViewModels =
                    anItemsViewModelManager.GetItemsViewByIdAndCompany(Convert.ToInt32(itemDropDownList.SelectedValue),
                        Convert.ToInt32(companyDropDownList.SelectedValue));
                availableQuantityTextBox.Text = (anItemsViewModels.AvailableQuantity -
                                                 QuantityInCart(anItemsViewModels.Id, anItemsViewModels.CompanyId)).ToString();
                reOrderLevelTextBox.Text = anItemsViewModels.ReOrderLevel.ToString();
            }
            else
            {
                Response.Write("<script>alert('" + ConstantMessage.invalid + "')</script>");
            }
        }

        // How many of this item are already in the cart, so the page shows (and checks against) what is left.
        private int QuantityInCart(int itemId, int companyId)
        {
            int quantity = 0;
            foreach (StockOut stockOut in (List<StockOut>)ViewState["ListVS"])
            {
                if (stockOut.ItemId == itemId && stockOut.CompanyId == companyId)
                {
                    quantity += stockOut.StockOutAmount;
                }
            }
            return quantity;
        }

        protected void addButton_Click(object sender, EventArgs e)
        {

            
            int stockOutAmount;
                if (companyDropDownList.SelectedValue != ConstantMessage.selectMessage &&
                    itemDropDownList.SelectedValue != ConstantMessage.selectMessage &&
                    stockOutQuantityTextBox.Text != String.Empty &&
                    int.TryParse(stockOutQuantityTextBox.Text, out stockOutAmount))
                {
                    StockOut aStockOut = new StockOut();
                    aStockOut.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                    aStockOut.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                    aStockOut.CompanyName = companyDropDownList.SelectedItem.Text;
                    aStockOut.ItemName = itemDropDownList.SelectedItem.Text;
                    aStockOut.Date = DateTime.Today.ToString("yyyy-MM-dd");
                    aStockOut.StockOutAmount = stockOutAmount;
                    if (stockOutAmount > 0 && stockOutAmount <= Convert.ToInt32(availableQuantityTextBox.Text))
                    {
                        List<StockOut> aList = (List<StockOut>) ViewState["ListVS"];
                            int f = 0;
                            foreach (StockOut stockOut in aList)
                            {
                                if (stockOut.CompanyId == aStockOut.CompanyId && stockOut.ItemId == aStockOut.ItemId)
                                {
                                    stockOut.StockOutAmount += aStockOut.StockOutAmount;
                                    availableQuantityTextBox.Text =(Convert.ToInt32(availableQuantityTextBox.Text) -
                                                                    stockOutAmount).ToString();
                                    stockOutGridView.DataSource = aList;
                                    stockOutGridView.DataBind(); 
                                    f = 1;
                                    break;

                                }
                            }
                        if (f == 0)
                        {
                            aList.Add(aStockOut);
                            availableQuantityTextBox.Text = (Convert.ToInt32(availableQuantityTextBox.Text) -
                                                                    stockOutAmount).ToString();
                            stockOutGridView.DataSource = aList;
                            stockOutGridView.DataBind();
                        }
                        ViewState["ListVS"] = aList;
                        

                    }
                    else
                    {
                        Response.Write("<script>alert('" + ConstantMessage.invalid + "')</script>");
                    }


                }
                else
                {
                    Response.Write("<script>alert('" + ConstantMessage.invalid + "')</script>");
                }


            }
        



        protected void stockOutGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            SaveStockOut("Sell");
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            SaveStockOut("Damage");
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            SaveStockOut("Lost");
        }

        // Saves the whole cart as one stock out of the given type (Sell, Damage or Lost), then empties the cart.
        private void SaveStockOut(string stockOutType)
        {
            List<StockOut> aList = (List<StockOut>)ViewState["ListVS"];
            foreach (StockOut stock in aList)
            {
                stock.StockOutType = stockOutType;
            }
            string message = aStockOutManager.Save(aList);
            ViewState["ListVS"] = new List<StockOut>();
            // The message can contain an item name, so encode it for the JavaScript string.
            Response.Write("<script>alert('" + HttpUtility.JavaScriptStringEncode(message) + "')</script>");
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            if (companyDropDownList.SelectedValue != ConstantMessage.selectMessage &&
                itemDropDownList.SelectedValue != ConstantMessage.selectMessage)
            {
                ItemsViewModels updatedItemsViewModels = anItemsViewModelManager.GetItemsViewByIdAndCompany(Convert.ToInt32(itemDropDownList.SelectedValue),
                    Convert.ToInt32(companyDropDownList.SelectedValue));
                availableQuantityTextBox.Text = updatedItemsViewModels.AvailableQuantity.ToString();
            }
            stockOutQuantityTextBox.Text = String.Empty;
        }
    }
}