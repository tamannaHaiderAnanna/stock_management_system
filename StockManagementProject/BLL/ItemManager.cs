using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Gateway;
using StockManagementProject.DAL.Models;
using StockManagementProject.Utility;

namespace StockManagementProject.BLL
{
    
    public class ItemManager
    {
        ItemGateway anItemGateway = new ItemGateway();
        public string Save(Item anItem)
        {
            if (anItemGateway.IsItemExists(anItem.ItemName))
            {
                return ConstantMessage.duplicateMessage;
            }
            int rowffect = anItemGateway.Save(anItem);
            if (rowffect > 0)
            {
                return ConstantMessage.saveSuccesful;
            }
            return ConstantMessage.saveFailed;
        }
    }
}