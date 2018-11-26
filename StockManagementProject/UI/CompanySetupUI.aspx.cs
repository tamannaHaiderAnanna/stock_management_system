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
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            companyGridView.DataSource = aCompanyManager.GetACompanies();
            companyGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != String.Empty)
            {
                Company aCompany = new Company();
                aCompany.CompanyName = nameTextBox.Text;
                string message = aCompanyManager.Save(aCompany);
                outputLabel.Text = message;
                nameTextBox.Text=String.Empty;
            }
            else
            {
                Response.Write("<script>alert('" + ConstantMessage.invalid + "')</script>");
            }
            companyGridView.DataSource = aCompanyManager.GetACompanies();
            companyGridView.DataBind();
        }
    }
}