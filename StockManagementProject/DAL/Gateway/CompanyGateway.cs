using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Models;

namespace StockManagementProject.DAL.Gateway
{
    public class CompanyGateway:BaseGateway
    {
        public int Save(Company aCompany)
        {
            string query = "INSERT INTO Company(CompanyName) VALUES(@companyName)";
            Command= new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@companyName", aCompany.CompanyName);
            Connection.Open();
            int rowEffect=Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }

        public bool IsCompanyExists(string companyName)
        {
            string query = "SELECT * FROM Company WHERE CompanyName=@companyName";
            Command= new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@companyName", companyName);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExists = Reader.HasRows;
            Connection.Close();
            return IsExists;
        }

        public List<Company> GetAllCompanies()
        {
            List<Company> companyList = new List<Company>();
            string query = "SELECT * FROM Company";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Company aCompany = new Company();
                    aCompany.Id = Convert.ToInt32(Reader["Id"]);
                    aCompany.CompanyName = Reader["CompanyName"].ToString();
                    companyList.Add(aCompany);

                }
            }
            Connection.Close();
            return companyList;
        }
    }
}