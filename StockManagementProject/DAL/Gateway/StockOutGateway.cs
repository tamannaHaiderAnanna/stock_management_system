using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Models;

namespace StockManagementProject.DAL.Gateway
{
    [Serializable]
    public class StockOutGateway:BaseGateway
    {
        public int Save(List<StockOut> aList)
        {
            int rowEffect=0;
            foreach (StockOut aStock in aList)
            {
                string query =
                    "INSERT INTO StockOutRecord (ItemId,CompanyId,StockOutQuantity,StockOutType,Date) VALUES(@itemId,@companyId,@stockOutQuantity,@stockOutType,@date)";
                Command = new SqlCommand(query,Connection);
                Command.Parameters.AddWithValue("@itemId", aStock.ItemId);
                Command.Parameters.AddWithValue("@companyId", aStock.CompanyId);
                Command.Parameters.AddWithValue("@stockOutQuantity", aStock.StockOutAmount);
                Command.Parameters.AddWithValue("@stockOutType", aStock.StockOutType);
                Command.Parameters.AddWithValue("@date", aStock.Date);
                Connection.Open();
                rowEffect = Command.ExecuteNonQuery();
                Connection.Close();

            }
            return rowEffect;
        }
    }
}