using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProject.BLL;
using StockManagementProject.DAL.Models;
using StockManagementProject.Utility;

namespace StockManagementProject.UI
{
    [Serializable]
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        private CategoryManager aCategoryManager = new CategoryManager();
        private CompanyManager aCompanyManager = new CompanyManager();
        ItemManager anItemManager = new ItemManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = aCompanyManager.GetACompanies();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Add(ConstantMessage.selectMessage);
                companyDropDownList.SelectedValue = ConstantMessage.selectMessage;
                categoryDropDownList.DataSource = aCategoryManager.GetAllCategories();
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Add(ConstantMessage.selectMessage);
                categoryDropDownList.SelectedValue = ConstantMessage.selectMessage;
                reOrderLevelTextBox.Text = "0";
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            int reOrderLevel;
            if (companyDropDownList.SelectedValue != ConstantMessage.selectMessage &&
                categoryDropDownList.SelectedValue != ConstantMessage.selectMessage &&
                itemNameTextBox.Text != String.Empty && int.TryParse(reOrderLevelTextBox.Text, out reOrderLevel) && System.Text.RegularExpressions.Regex.IsMatch(itemNameTextBox.Text, "^[a-zA-Z ]"))
            {
                if (reOrderLevel >= 0)
                {

                    Item anItem = new Item();
                    anItem.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                    anItem.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                    anItem.ItemName = itemNameTextBox.Text;

                    if (reOrderLevelTextBox.Text == String.Empty)
                    {
                        anItem.ReOrderLevel = 0;
                    }
                    else
                    {
                        anItem.ReOrderLevel = reOrderLevel;
                    }

                    string message = anItemManager.Save(anItem);
                    reOrderLevelTextBox.Text = "0";
                    itemNameTextBox.Text = String.Empty;
                    outputLabel.Text = message;
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
