using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProject.BLL;
using StockManagementProject.Utility;

namespace StockManagementProject.UI
{
    [Serializable]
    public partial class SearchAndViewItemsUI : System.Web.UI.Page
    {
        SearchAndViewItemsManager aSearchAndViewItemsManager = new SearchAndViewItemsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = aSearchAndViewItemsManager.GetCompanies();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Add(ConstantMessage.selectMessage);
                companyDropDownList.SelectedValue = ConstantMessage.selectMessage;
                categoryDropDownList.DataSource = aSearchAndViewItemsManager.GetCategories();
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataBind();
                
                categoryDropDownList.Items.Add(ConstantMessage.selectMessage);
                categoryDropDownList.SelectedValue = ConstantMessage.selectMessage;
                itemsViewGridView.DataSource = aSearchAndViewItemsManager.GetAllItemsViewModels();
                itemsViewGridView.DataBind();
            }
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedValue != ConstantMessage.selectMessage)
            {
                categoryDropDownList.DataSource =
                    aSearchAndViewItemsManager.GetCategoriesByCompanyId(
                        Convert.ToInt32(companyDropDownList.SelectedValue));
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Add(ConstantMessage.selectMessage);
                categoryDropDownList.SelectedValue = ConstantMessage.selectMessage;
            }
            else
            {
                categoryDropDownList.DataSource = aSearchAndViewItemsManager.GetCategories();
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Add(ConstantMessage.selectMessage);
                categoryDropDownList.SelectedValue = ConstantMessage.selectMessage;
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

                if (companyDropDownList.SelectedValue == ConstantMessage.selectMessage &&
                    categoryDropDownList.SelectedValue != ConstantMessage.selectMessage)
                {
                    itemsViewGridView.DataSource =
                        aSearchAndViewItemsManager.GetItemsViewModelsByCategory(
                            Convert.ToInt32(categoryDropDownList.SelectedValue));
                    itemsViewGridView.DataBind();
                }
                else if (companyDropDownList.SelectedValue != ConstantMessage.selectMessage &&
                         categoryDropDownList.SelectedValue == ConstantMessage.selectMessage)
                {
                    itemsViewGridView.DataSource =
                        aSearchAndViewItemsManager.GetItemsViewModelsByCompany(
                            Convert.ToInt32(companyDropDownList.SelectedValue));
                    itemsViewGridView.DataBind();
                }
                else if(companyDropDownList.SelectedValue!=ConstantMessage.selectMessage&&categoryDropDownList.SelectedValue!=ConstantMessage.selectMessage)
                {
                    itemsViewGridView.DataSource =
                        aSearchAndViewItemsManager.GetItemsViewModelsByCompanyAndCategory(
                            Convert.ToInt32(categoryDropDownList.SelectedValue),
                            Convert.ToInt32(companyDropDownList.SelectedValue));
                    itemsViewGridView.DataBind();
                    
                }
                else
                {
                    itemsViewGridView.DataSource = aSearchAndViewItemsManager.GetAllItemsViewModels();
                    itemsViewGridView.DataBind();
                }

            }
        }
    }
