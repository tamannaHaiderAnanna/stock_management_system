using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Models;

namespace StockManagementProject.DAL.Gateway
{
    [Serializable]
    public class StockInGateway:BaseGateway
    {
        public int StockInUpdate(StockIn aStockIn)
        {
            string query =
                "UPDATE Items SET AvailableQuantity=AvailableQuantity+@stockInAmount WHERE CompanyId=@companyId AND Id=@itemId";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@stockInAmount", aStockIn.StockInAmount);
            Command.Parameters.AddWithValue("@companyId", aStockIn.CompanyId);
            Command.Parameters.AddWithValue("@itemId", aStockIn.ItemId);
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;

        }

        public int StockInDelete(List<StockOut> aList)
        {
            int rowEffect = 0;
            foreach (StockOut stockOut in aList)
            {
                string query = "UPDATE Items SET AvailableQuantity=AvailableQuantity-@stockOut WHERE ItemName=@itemName AND CompanyId=@companyId";
                Command = new SqlCommand(query,Connection);
                Command.Parameters.AddWithValue("@stockOut", stockOut.StockOutAmount);
                Command.Parameters.AddWithValue("@itemName", stockOut.ItemName);
                Command.Parameters.AddWithValue("@companyId", stockOut.CompanyId);
                Connection.Open();
                rowEffect = Command.ExecuteNonQuery();
                Connection.Close();

            }
            return rowEffect;
        }
    }
}