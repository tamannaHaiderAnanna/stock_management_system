using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementProject.DAL.Models.ViewModels
{
    public class StockOutViewModel
    {
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public int StockOutQuantity { get; set; }
    }
}