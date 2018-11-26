using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Gateway;
using StockManagementProject.DAL.Models;
using StockManagementProject.Utility;

namespace StockManagementProject.BLL
{
    public class StockInManager
    {
        StockInGateway aStockInGateway = new StockInGateway();
        public string StockInUpdate(StockIn aStockIn)
        {
            int rowEffect = aStockInGateway.StockInUpdate(aStockIn);
            if (rowEffect > 0)
            {
                return ConstantMessage.saveSuccesful;
            }
            return ConstantMessage.saveFailed;
        }
    }
}