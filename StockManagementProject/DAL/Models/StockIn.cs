using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementProject.DAL.Models
{
    [Serializable]
    public class StockIn
    {
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public int StockInAmount { get; set; }
    }
}