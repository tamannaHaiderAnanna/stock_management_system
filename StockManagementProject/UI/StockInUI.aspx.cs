using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProject.BLL;
using StockManagementProject.DAL.Models;
using StockManagementProject.DAL.Models.ViewModels;
using StockManagementProject.Utility;

namespace StockManagementProject.UI
{
    [Serializable]
    public partial class StockInUI : System.Web.UI.Page
    {
       StockInManager aStockInManager = new StockInManager();
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
                quantityTextBox.Text = anItemsViewModels.AvailableQuantity.ToString();
                reOrderLevelTextBox.Text = anItemsViewModels.ReOrderLevel.ToString();
            }
            else
            {
                Response.Write("<script>alert('" + ConstantMessage.invalid + "')</script>");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            int stockInAmount;
            if (companyDropDownList.SelectedValue != ConstantMessage.selectMessage &&
                itemDropDownList.SelectedValue != ConstantMessage.selectMessage&&stockInTextBox.Text!=String.Empty&&int.TryParse(stockInTextBox.Text, out stockInAmount))
            {
                
                StockIn aStockIn = new StockIn();
                aStockIn.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                aStockIn.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                aStockIn.StockInAmount = stockInAmount;
                if (aStockIn.StockInAmount > 0)
                {
                    string message = aStockInManager.StockInUpdate(aStockIn);
                    outputLabel.Text = message;
                                    ItemsViewModels anItemsViewModels =
                    anItemsViewModelManager.GetItemsViewByIdAndCompany(Convert.ToInt32(itemDropDownList.SelectedValue),
                        Convert.ToInt32(companyDropDownList.SelectedValue));
                    quantityTextBox.Text = anItemsViewModels.AvailableQuantity.ToString();
                }
                else
                {
                    Response.Write("<script>alert('" + ConstantMessage.negative + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('" + ConstantMessage.invalid + "')</script>");
            }
        }
    }
}