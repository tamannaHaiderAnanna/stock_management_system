using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Models.ViewModels;

namespace StockManagementProject.DAL.Gateway
{
    public class ViewSalesGateway:BaseGateway
    {
        public List<StockOutViewModel> GetSalesBetweenDates(string fromDate, string toDate)
        {
            List<StockOutViewModel> aStockOutViewModels = new List<StockOutViewModel>();
            string query =
                "SELECT ItemName,CompanyName,SUM(StockOutQuantity) AS TotalSale FROM StockOutView WHERE StockOutType='Sell' AND Date BETWEEN @fromDate AND @toDate Group By ItemName,CompanyName";
            Command= new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@fromDate", fromDate);
            Command.Parameters.AddWithValue("@toDate", toDate);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                
                while (Reader.Read())
                {
                    StockOutViewModel aStockOutViewModel = new StockOutViewModel();
                    aStockOutViewModel.ItemName = Reader["ItemName"].ToString();
                    aStockOutViewModel.CompanyName = Reader["CompanyName"].ToString();
                    aStockOutViewModel.StockOutQuantity = Convert.ToInt32(Reader["TotalSale"]);
                    aStockOutViewModels.Add(aStockOutViewModel);
                }
                    
                
            }
            Connection.Close();
            return aStockOutViewModels;

        }
 
    }
}