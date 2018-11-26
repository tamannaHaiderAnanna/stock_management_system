using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Gateway;
using StockManagementProject.DAL.Models.ViewModels;

namespace StockManagementProject.BLL
{
    public class ViewSalesManager
    { ViewSalesGateway aViewSalesGateway = new ViewSalesGateway();

        public List<StockOutViewModel> GetAllReportsBetweenDates(string fromDate, string toDate)
        {
            return aViewSalesGateway.GetSalesBetweenDates(fromDate, toDate);
        }
    }
}