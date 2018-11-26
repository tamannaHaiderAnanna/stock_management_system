using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProject.BLL;
using StockManagementProject.Utility;

namespace StockManagementProject.UI
{
    public partial class ViewSalesReport : System.Web.UI.Page
    {
        ViewSalesManager aViewSalesManager = new ViewSalesManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDayDropDownList.SelectedValue + "/" + fromMonthDropDownList.SelectedValue + "/" + fromYearDropDownList.SelectedValue;
            DateTime fromDateTime = Convert.ToDateTime(fromDate);
            string toDate = toDayDropDownList.SelectedValue + "/" + toMonthDropDownList.SelectedValue + "/" + toYearDropDownList.SelectedValue;
            DateTime toDateTime = Convert.ToDateTime(toDate);
            int result = DateTime.Compare(fromDateTime, toDateTime);

            if (result <= 0)
            {
                viewSalesGridView.DataSource =
                    aViewSalesManager.GetAllReportsBetweenDates(fromDateTime.ToString("yyyy-MM-dd"),
                        toDateTime.ToString("yyyy-MM-dd"));
                viewSalesGridView.DataBind();
            }

            else
            {
                Response.Write("<script>alert('" + ConstantMessage.invalid + "')</script>");
            }
                

        }
    }
}