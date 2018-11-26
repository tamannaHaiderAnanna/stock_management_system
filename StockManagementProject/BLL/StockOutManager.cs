using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Gateway;
using StockManagementProject.DAL.Models;
using StockManagementProject.Utility;

namespace StockManagementProject.BLL
{
    [Serializable]
    public class StockOutManager
    {
        StockOutGateway aStockOutGateway = new StockOutGateway();
        StockInGateway aStockInGateway = new StockInGateway();
        public string Save(List<StockOut> aList)
        {
            int rowEffect1 = aStockOutGateway.Save(aList);
            int rowEffect2 = aStockInGateway.StockInDelete(aList);
            if (rowEffect1 > 0&&rowEffect2>0)
            {
                return ConstantMessage.stockOut;
            }
            return ConstantMessage.invalid;
        }
    }
}