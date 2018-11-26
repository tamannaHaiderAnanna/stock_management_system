using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Gateway;
using StockManagementProject.DAL.Models;
using StockManagementProject.DAL.Models.ViewModels;

namespace StockManagementProject.BLL
{
    [Serializable]
    public class ItemsViewModelManager
    { 
        ItemsViewModelGateway anItemsViewModelGateway = new ItemsViewModelGateway();

        public List<ItemsViewModels> GetAllItemsView()
        {
            return anItemsViewModelGateway.GetAllItemsViewModels();
        }

        public List<ItemsViewModels> GetAllItemsViewByCompany(int companyId)
        {
            return anItemsViewModelGateway.GetItemsViewByCompany(companyId);
        }

        public ItemsViewModels GetItemsViewByIdAndCompany(int itemId, int companyId)
        {
            return anItemsViewModelGateway.GetItemsViewByIdAndCompany(itemId, companyId);
        }

        public List<Company> GetCompanies()
        {
            return anItemsViewModelGateway.GetDistinctCompanies();
        }
    }
}