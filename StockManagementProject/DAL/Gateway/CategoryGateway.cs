using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Models;

namespace StockManagementProject.DAL.Gateway
{
    public class CategoryGateway:BaseGateway
    {
        public int Save(Category aCategory)
        {
            string query = "INSERT INTO Category(CategoryName) VALUES (@categoryName)";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@categoryName", aCategory.CategoryName);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }

        public bool IsCategoryExist(string categoryName)
        {
            string query = "SELECT * FROM Category WHERE CategoryName=@categoryName";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@categoryName", categoryName);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> aCategoryList = new List<Category>();
            string query = "SELECT * FROM Category";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Category aCategory = new Category();
                    aCategory.Id = Convert.ToInt32(Reader["Id"]);
                    aCategory.CategoryName = Reader["CategoryName"].ToString();
                    aCategoryList.Add(aCategory);
                }
            }
            Connection.Close();
            return aCategoryList;
        }

        public Category GetCategoryById(int id)
        {
            string query = "SELECT * FROM Category WHERE Id=@id";
            Command =new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@id", id);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Category aCategory = null;
            if (Reader.HasRows)
            {
                Reader.Read();
                aCategory = new Category();
                aCategory.Id = Convert.ToInt32(Reader["Id"]);
                aCategory.CategoryName = Reader["CategoryName"].ToString();

            }
            Connection.Close();
            return aCategory;
        }

        public int UpdateCategoryById(int id,string categoryName)
        {
            string query = "UPDATE Category SET CategoryName=@categoryName WHERE Id=@id";
            Command= new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@categoryName", categoryName);
            Command.Parameters.AddWithValue("@id", id);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }
    }
}