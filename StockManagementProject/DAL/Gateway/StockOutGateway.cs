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
        // Takes every item in the list out of stock and records it, all in one transaction. An item's stock
        // only goes down if there is enough of it, checked in the same UPDATE, so two pages selling the same
        // item can't take it below zero. Returns the first item without enough stock (and then nothing at
        // all is saved), or null when everything was saved.
        public StockOut Save(List<StockOut> aList)
        {
            Connection.Open();
            SqlTransaction transaction = Connection.BeginTransaction();
            try
            {
                // In item order, so two sales of the same items lock them in the same order and can't deadlock.
                foreach (StockOut aStock in aList.OrderBy(s => s.ItemId))
                {
                    string query =
                        "UPDATE Items SET AvailableQuantity=AvailableQuantity-@stockOutQuantity WHERE Id=@itemId AND CompanyId=@companyId AND AvailableQuantity>=@stockOutQuantity";
                    Command = new SqlCommand(query,Connection,transaction);
                    Command.Parameters.AddWithValue("@stockOutQuantity", aStock.StockOutAmount);
                    Command.Parameters.AddWithValue("@itemId", aStock.ItemId);
                    Command.Parameters.AddWithValue("@companyId", aStock.CompanyId);
                    if (Command.ExecuteNonQuery() == 0)
                    {
                        transaction.Rollback();
                        Connection.Close();
                        return aStock;
                    }

                    query =
                        "INSERT INTO StockOutRecord (ItemId,CompanyId,StockOutQuantity,StockOutType,Date) VALUES(@itemId,@companyId,@stockOutQuantity,@stockOutType,@date)";
                    Command = new SqlCommand(query,Connection,transaction);
                    Command.Parameters.AddWithValue("@itemId", aStock.ItemId);
                    Command.Parameters.AddWithValue("@companyId", aStock.CompanyId);
                    Command.Parameters.AddWithValue("@stockOutQuantity", aStock.StockOutAmount);
                    Command.Parameters.AddWithValue("@stockOutType", aStock.StockOutType);
                    Command.Parameters.AddWithValue("@date", aStock.Date);
                    Command.ExecuteNonQuery();
                }
                transaction.Commit();
                Connection.Close();
                return null;
            }
            catch
            {
                // SQL Server may already have rolled the transaction back itself.
                if (transaction.Connection != null)
                {
                    transaction.Rollback();
                }
                Connection.Close();
                throw;
            }
        }
    }
}