using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Gateway;
using StockManagementProject.DAL.Models;
using StockManagementProject.DAL.Models.ViewModels;
using StockManagementProject.Utility;

namespace StockManagementProject.BLL
{
    [Serializable]
    public class StockOutManager
    {
        StockOutGateway aStockOutGateway = new StockOutGateway();
        ItemsViewModelGateway anItemsViewModelGateway = new ItemsViewModelGateway();
        public string Save(List<StockOut> aList)
        {
            if (aList.Count == 0)
            {
                return ConstantMessage.invalid;
            }
            StockOut notEnough = aStockOutGateway.Save(aList);
            if (notEnough != null)
            {
                ItemsViewModels anItem = anItemsViewModelGateway.GetItemsViewByIdAndCompany(notEnough.ItemId, notEnough.CompanyId);
                return string.Format(ConstantMessage.notEnoughStock, notEnough.ItemName, anItem.AvailableQuantity);
            }
            return ConstantMessage.stockOut;
        }
    }
}