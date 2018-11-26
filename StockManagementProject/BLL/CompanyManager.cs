using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProject.DAL.Gateway;
using StockManagementProject.DAL.Models;
using StockManagementProject.Utility;

namespace StockManagementProject.BLL
{
    public class CompanyManager
    {
        CompanyGateway aCompanyGateway = new CompanyGateway();
        
        public string Save(Company aCompany)
        {
            if (aCompanyGateway.IsCompanyExists(aCompany.CompanyName))
            {
                return ConstantMessage.duplicateMessage;
            }
            int rowEffect = aCompanyGateway.Save(aCompany);
            if (rowEffect > 0)
            {
                return ConstantMessage.saveSuccesful;
            }
            return ConstantMessage.saveFailed;
        }

        public List<Company> GetACompanies()
        {
            return aCompanyGateway.GetAllCompanies();
        }
    }
}