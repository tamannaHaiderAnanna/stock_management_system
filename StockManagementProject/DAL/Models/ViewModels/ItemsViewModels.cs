using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementProject.DAL.Models.ViewModels
{
    public class ItemsViewModels
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public int AvailableQuantity { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int ReOrderLevel { get; set; }
    }
}