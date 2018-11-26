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
    public partial class CategoryUI : System.Web.UI.Page
    {
        CategoryManager aCategoryManager = new CategoryManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryGridView.DataSource = aCategoryManager.GetAllCategories();
            categoryGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (categoryNameTextBox.Text != String.Empty && System.Text.RegularExpressions.Regex.IsMatch(categoryNameTextBox.Text, "^[a-zA-Z ]"))
            {
                Category aCategory = new Category();
                aCategory.CategoryName = categoryNameTextBox.Text;
                string message = aCategoryManager.Save(aCategory);
                outputLabel.Text = message;
                
                categoryNameTextBox.Text = String.Empty;
            }
            else
            {
                Response.Write("<script>alert('"+ConstantMessage.invalid+"')</script>");

            }
            categoryGridView.DataSource = aCategoryManager.GetAllCategories();
            categoryGridView.DataBind();

        }
        protected void updateLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton linkbutton = sender as LinkButton;
            DataControlFieldCell cell = linkbutton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField idHiddenField = row.FindControl("idHiddenfield") as HiddenField;
            int id = Convert.ToInt32(idHiddenField.Value);
            Response.Redirect("EditCategoryUI.aspx?Id="+id);
        }
    }
}