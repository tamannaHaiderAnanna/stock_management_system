using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (!IsPostBack)
            {
                // Days 1-31 and every year from 2010 up to this one. The report starts on 1 January of
                // this year and ends today.
                for (int day = 1; day <= 31; day++)
                {
                    fromDayDropDownList.Items.Add(day.ToString());
                    toDayDropDownList.Items.Add(day.ToString());
                }
                for (int year = 2010; year <= DateTime.Today.Year; year++)
                {
                    fromYearDropDownList.Items.Add(year.ToString());
                    toYearDropDownList.Items.Add(year.ToString());
                }
                DateTime today = DateTime.Today;
                fromDayDropDownList.SelectedValue = "1";
                fromMonthDropDownList.SelectedValue = "Jan";
                fromYearDropDownList.SelectedValue = today.Year.ToString();
                toDayDropDownList.SelectedValue = today.Day.ToString();
                toMonthDropDownList.SelectedValue = today.ToString("MMM", CultureInfo.InvariantCulture);
                toYearDropDownList.SelectedValue = today.Year.ToString();
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            DateTime fromDateTime;
            DateTime toDateTime;
            if (!TryGetDate(fromDayDropDownList, fromMonthDropDownList, fromYearDropDownList, out fromDateTime) ||
                !TryGetDate(toDayDropDownList, toMonthDropDownList, toYearDropDownList, out toDateTime))
            {
                Response.Write("<script>alert('" + ConstantMessage.invalidDate + "')</script>");
                return;
            }
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

        // Reads a day, month name (Jan, Feb, ...) and year the same way on any server. An impossible
        // date such as 31 Feb gives false instead of crashing the page.
        private static bool TryGetDate(DropDownList day, DropDownList month, DropDownList year, out DateTime date)
        {
            return DateTime.TryParseExact(day.SelectedValue + "/" + month.SelectedValue + "/" + year.SelectedValue,
                "d/MMM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
    }
}