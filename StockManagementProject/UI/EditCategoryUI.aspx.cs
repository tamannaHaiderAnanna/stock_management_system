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
    public partial class EditCategoryUI : System.Web.UI.Page
    {
        CategoryManager aCategoryManager = new CategoryManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int id = Convert.ToInt32(Request.QueryString["Id"]);
                
                Category aCategory = new Category();

                aCategory = aCategoryManager.GetCategoryById(id);
                if (aCategory != null)
                {
                    categoryUpdateTextBox.Text = aCategory.CategoryName;
                }
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (categoryUpdateTextBox.Text != String.Empty && System.Text.RegularExpressions.Regex.IsMatch(categoryUpdateTextBox.Text, "^[a-zA-Z ]"))
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                string newCategoryName = categoryUpdateTextBox.Text;
                string message = aCategoryManager.UpdateCategoryById(id, newCategoryName);
                if (message == ConstantMessage.saveSuccesful)
                {
                    Response.Redirect("CategoryUI.aspx");
                }
                outputLabel.Text = ConstantMessage.duplicateMessage;
            }
            else
            {
                Response.Write("<script>alert('" + ConstantMessage.invalid + "')</script>");
            }
        }
    }
}