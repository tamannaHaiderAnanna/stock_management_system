using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Models;

namespace StockManagementProject.DAL.Gateway
{
    public class ItemGateway:BaseGateway
    {
        public int Save(Item anItem)
        {
            string query =
                "INSERT INTO Items(CategoryId,CompanyId,ItemName,ReOrderLevel,AvailableQuantity) VALUES(@categoryId,@companyId,@itemName,@reOrderLevel,0)";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@categoryId", anItem.CategoryId);
            Command.Parameters.AddWithValue("@companyId", anItem.CompanyId);
            Command.Parameters.AddWithValue("@itemName", anItem.ItemName);
            Command.Parameters.AddWithValue("@reOrderLevel", anItem.ReOrderLevel);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }

        public bool IsItemExists(string itemName)
        {
            string query = "SELECT * FROM Items WHERE ItemName=@itemName";
            Command= new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@itemName", itemName);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }

    }
}