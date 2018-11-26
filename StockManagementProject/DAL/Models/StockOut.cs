using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementProject.DAL.Models
{
    [Serializable]
    public class StockOut
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int CompanyId { get; set; }
        public int StockOutAmount { get; set; }
        public string StockOutType { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public string Date { get; set; }
            
       
    }
}