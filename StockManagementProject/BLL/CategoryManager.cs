using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Gateway;
using StockManagementProject.DAL.Models;
using StockManagementProject.Utility;

namespace StockManagementProject.BLL
{
    public class CategoryManager
    {
        CategoryGateway aCategoryGateway = new CategoryGateway();
        

        public string Save(Category aCategory)
        {
            if (aCategoryGateway.IsCategoryExist(aCategory.CategoryName))
            {
                return ConstantMessage.duplicateMessage;
            }
            else
            {
                int rowEffect = aCategoryGateway.Save(aCategory);
                if (rowEffect > 0)
                {
                    return ConstantMessage.saveSuccesful;
                }
            }

            return ConstantMessage.saveFailed;
        }

        public List<Category> GetAllCategories()
        {
            return aCategoryGateway.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
           return aCategoryGateway.GetCategoryById(id);
        }

        public string UpdateCategoryById(int id, string categoryName)
        {
            if (aCategoryGateway.IsCategoryExist(categoryName))
            {
                return ConstantMessage.duplicateMessage;
            }
            else
            {
                int rowEffect = aCategoryGateway.UpdateCategoryById(id,categoryName);
                if (rowEffect > 0)
                {
                    return ConstantMessage.saveSuccesful;
                }
            }

            return ConstantMessage.saveFailed;

        }
    }
}