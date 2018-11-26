using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Gateway;
using StockManagementProject.DAL.Models;
using StockManagementProject.DAL.Models.ViewModels;

namespace StockManagementProject.BLL
{
    public class SearchAndViewItemsManager
    {
        ItemsViewModelGateway anItemsViewModelGateway = new ItemsViewModelGateway();

        public List<ItemsViewModels> GetAllItemsViewModels()
        {
            return anItemsViewModelGateway.GetAllItemsViewModels();
        }

        public List<ItemsViewModels> GetItemsViewModelsByCompany(int companyId)
        {
            return anItemsViewModelGateway.GetItemsViewByCompany(companyId);
        }

        public List<ItemsViewModels> GetItemsViewModelsByCategory(int categoryId)
        {
            return anItemsViewModelGateway.GetAllItemsViewByCategories(categoryId);
        }

        public List<ItemsViewModels> GetItemsViewModelsByCompanyAndCategory(int categoryId, int companyId)
        {
            return anItemsViewModelGateway.GetAllItemsViewByCategoryAndCompany(categoryId, companyId);
        }

        public List<Company> GetCompanies()
        {
            return anItemsViewModelGateway.GetDistinctCompanies();
        }

        public List<Category> GetCategoriesByCompanyId(int companyId)
        {
            return anItemsViewModelGateway.GetDistinctCategoriesByCompanyId(companyId);
        }

        public List<Category> GetCategories()
        {
            return anItemsViewModelGateway.GetAllDistinctCategories();
        }
    }
}