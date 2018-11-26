using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Models;
using StockManagementProject.DAL.Models.ViewModels;

namespace StockManagementProject.DAL.Gateway
{
    [Serializable]
    public class ItemsViewModelGateway:BaseGateway
    {
        public List<ItemsViewModels> GetAllItemsViewModels()
        {
            List<ItemsViewModels> anItemsViewModelList = new List<ItemsViewModels>();
            string query = "SELECT * FROM ItemsView";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    ItemsViewModels anItemsViewModels = new ItemsViewModels();
                    anItemsViewModels.CategoryName = Reader["CategoryName"].ToString();
                    anItemsViewModels.ItemName = Reader["ItemName"].ToString();
                    anItemsViewModels.CompanyName = Reader["CompanyName"].ToString();
                    anItemsViewModels.Id = Convert.ToInt32(Reader["Id"]);
                    anItemsViewModels.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                    anItemsViewModels.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                    anItemsViewModels.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                    anItemsViewModels.ReOrderLevel = Convert.ToInt32(Reader["ReOrderLevel"]);
                    anItemsViewModelList.Add(anItemsViewModels);
                }
            }
            Connection.Close();
            return anItemsViewModelList;
        }

        public List<ItemsViewModels> GetItemsViewByCompany(int companyId)
        {
            List<ItemsViewModels> anItemsViewModelList = new List<ItemsViewModels>();
            string query = "SELECT * FROM ItemsView WHERE CompanyId=@companyId";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@companyId", companyId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    ItemsViewModels anItemsViewModels = new ItemsViewModels();
                    anItemsViewModels.CategoryName = Reader["CategoryName"].ToString();
                    anItemsViewModels.ItemName = Reader["ItemName"].ToString();
                    anItemsViewModels.CompanyName = Reader["CompanyName"].ToString();
                    anItemsViewModels.Id = Convert.ToInt32(Reader["Id"]);
                    anItemsViewModels.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                    anItemsViewModels.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                    anItemsViewModels.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                    anItemsViewModels.ReOrderLevel = Convert.ToInt32(Reader["ReOrderLevel"]);
                    anItemsViewModelList.Add(anItemsViewModels);
                }
            }
            Connection.Close();
            return anItemsViewModelList;
        }

        public ItemsViewModels GetItemsViewByIdAndCompany(int itemId, int companyId)
        {
            string query = "SELECT * FROM ItemsView WHERE Id=@id AND CompanyId=@companyId";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@id", itemId);
            Command.Parameters.AddWithValue("@companyId", companyId);
            Connection.Open();
            ItemsViewModels anItemsViewModels = null;
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                anItemsViewModels = new ItemsViewModels();
                anItemsViewModels.CategoryName = Reader["CategoryName"].ToString();
                anItemsViewModels.ItemName = Reader["ItemName"].ToString();
                anItemsViewModels.CompanyName = Reader["CompanyName"].ToString();
                anItemsViewModels.Id = Convert.ToInt32(Reader["Id"]);
                anItemsViewModels.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                anItemsViewModels.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                anItemsViewModels.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                anItemsViewModels.ReOrderLevel = Convert.ToInt32(Reader["ReOrderLevel"]);
            }
            Connection.Close();

            return anItemsViewModels;
        }

        public List<Company> GetDistinctCompanies()
        {
            List<Company> aCompanyList = new List<Company>();
            string query = "SELECT DISTINCT CompanyName, CompanyId FROM ITEMSVIEW";
            Command= new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Company aCompany = new Company();
                    aCompany.CompanyName = Reader["CompanyName"].ToString();
                    aCompany.Id = Convert.ToInt32(Reader["CompanyId"]);
                    aCompanyList.Add(aCompany);

                }
            }
            Connection.Close();
            return aCompanyList;
        }

        public List<ItemsViewModels> GetAllItemsViewByCategories(int categoryId)
        {
            List<ItemsViewModels> anItemsViewModelList = new List<ItemsViewModels>();
            string query = "SELECT * FROM ItemsView WHERE CategoryId=@categoryId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@categoryId", categoryId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    ItemsViewModels anItemsViewModels = new ItemsViewModels();
                    anItemsViewModels.CategoryName = Reader["CategoryName"].ToString();
                    anItemsViewModels.ItemName = Reader["ItemName"].ToString();
                    anItemsViewModels.CompanyName = Reader["CompanyName"].ToString();
                    anItemsViewModels.Id = Convert.ToInt32(Reader["Id"]);
                    anItemsViewModels.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                    anItemsViewModels.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                    anItemsViewModels.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                    anItemsViewModels.ReOrderLevel = Convert.ToInt32(Reader["ReOrderLevel"]);
                    anItemsViewModelList.Add(anItemsViewModels);
                }
            }
            Connection.Close();
            return anItemsViewModelList;  
        }
        public List<ItemsViewModels> GetAllItemsViewByCategoryAndCompany(int categoryId,int companyId)
        {
            List<ItemsViewModels> anItemsViewModelList = new List<ItemsViewModels>();
            string query = "SELECT * FROM ItemsView WHERE CategoryId=@categoryId AND CompanyId=@companyId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@categoryId", categoryId);
            Command.Parameters.Add("@companyId", companyId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    ItemsViewModels anItemsViewModels = new ItemsViewModels();
                    anItemsViewModels.CategoryName = Reader["CategoryName"].ToString();
                    anItemsViewModels.ItemName = Reader["ItemName"].ToString();
                    anItemsViewModels.CompanyName = Reader["CompanyName"].ToString();
                    anItemsViewModels.Id = Convert.ToInt32(Reader["Id"]);
                    anItemsViewModels.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                    anItemsViewModels.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                    anItemsViewModels.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                    anItemsViewModels.ReOrderLevel = Convert.ToInt32(Reader["ReOrderLevel"]);
                    anItemsViewModelList.Add(anItemsViewModels);
                }
            }
            Connection.Close();
            return anItemsViewModelList;
        }
        public List<Category> GetDistinctCategoriesByCompanyId(int companyId)
        {
            List<Category> aCategoryList = new List<Category>();
            string query = "SELECT DISTINCT CategoryName,CategoryId FROM ITEMSVIEW WHERE CompanyId=@companyId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@companyId", companyId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Category aCategory = new Category();
                    aCategory.CategoryName = Reader["CategoryName"].ToString();
                    aCategory.Id = Convert.ToInt32(Reader["CategoryId"]);
                    aCategoryList.Add(aCategory);

                }
            }
            Connection.Close();
            return aCategoryList;
        }
        public List<Category> GetAllDistinctCategories()
        {
            List<Category> aCategoryList = new List<Category>();
            string query = "SELECT DISTINCT CategoryName,CategoryId FROM ITEMSVIEW ";
            Command = new SqlCommand(query, Connection);
            
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Category aCategory = new Category();
                    aCategory.CategoryName = Reader["CategoryName"].ToString();
                    aCategory.Id = Convert.ToInt32(Reader["CategoryId"]);
                    aCategoryList.Add(aCategory);

                }
            }
            Connection.Close();
            return aCategoryList;
        }
        
    }
}