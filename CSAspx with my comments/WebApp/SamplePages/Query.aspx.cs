
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region Additional Namespaces
using NorthwindSystem.BLL;
using Northwind.Data.Entities;
// use Manage NuGet Packages to add EntityFramework
// add the reference assembly System.Data.Entity
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
#endregion

namespace WebApp.SamplePages
{
    public partial class Query : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                BindProductList();
                //TODO: Code the methods for these calls
                BindSupplierList();
                BindCategoryList();
            }
        }

        public void BindProductList()
        {
            try
            {
                ProductController sysmgr = new ProductController();
                List<Product> info = sysmgr.Products_List();
                info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                ProductList.DataSource = info;
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, "select...");
            }
            catch(Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }
        
        
        public void BindSupplierList()
        {
            try
            {
                SupplierController sysmgr = new SupplierController();
                List<Supplier> info = sysmgr.Supplier_List();
                info.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));
                SupplierList.DataSource = info;
                SupplierList.DataTextField = nameof(Supplier.CompanyName); // look in .data xxxx.cs entity to find out what to put in these
                SupplierList.DataValueField = nameof(Supplier.SupplierID);
                SupplierList.DataBind();
                SupplierList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }

        public void BindCategoryList()
        {
            try
            {
                CategoryController sysmgr = new CategoryController(); // sysmgr is just a variable name Don likes to use
                List<Category> info = sysmgr.Category_List();
                info.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = info;
                CategoryList.DataTextField = nameof(Category.CategoryName);
                CategoryList.DataValueField = nameof(Category.CategoryID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }

        //use this method to discover the inner most error message.
        //this routine  has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void SearchProduct_Click(object sender, EventArgs e)
        {
            //TODO: code this method to lookup and display the selected product

            // do you have something to earch for? the dropdownlist has a prompt line in index 0
            if(ProductList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a product to fetch.");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
            else
            {
                // if you are leaving the web project to access code within another project, you should use user-friendly error handling
                try
                {
                    // to use an object, we must create an instance of the object, done on the line below
                    ProductController sysmgr = new ProductController(); // new instance of ProductController(), name is sysmgr

                    // call the appropriate method within our instance
                    // the value between the () is the selected option in the drop down list
                    // int.Parse to convert the string value into an int
                    // ProductList.SelectedValue is the actual data we need, and is being converted to int

                    Product info = sysmgr.Products_GetProduct(int.Parse(ProductList.SelectedValue));

                    // to test an error msg, search for a product that doesn't exist, seen in the line below
                    // YOU MUST REBUILD FIRST FOR THIS TO WORK
                    //Product info = sysmgr.Products_GetProduct(99999);

                    // check that a product was found
                    // single record data is checked against null
                    // multi record data is checked against .Count
                    // this depends on the TYPE OF QUERY

                    if (info == null)
                    {
                        // if product was not found, send a msg to the user
                        // also, list must be wrong, so we should refresh it 
                        errormsgs.Add("Product was not found. Select and try again.");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindProductList();
                    }
                    else
                    {
                        // product was found, now display
                        ProductID.Text = info.ProductID.ToString();
                        ProductName.Text = info.ProductName;
                        // we can't use selected index here, need to use selected value
                        SupplierList.SelectedValue = info.SupplierID == null ? "select..." : info.SupplierID.ToString();
                        // above is ternary operatior, basically short form "if" statement
                        CategoryList.SelectedValue = info.CategoryID == null ? "select..." : info.CategoryID.ToString();
                        QuantityPerUnit.Text = info.QuantityPerUnit == null ? "" : info.QuantityPerUnit;
                        UnitPrice.Text = info.UnitPrice == null ? "" : string.Format("{0:0.00}", info.UnitPrice);
                        UnitsInStock.Text = info.UnitsInStock == null ? "" : info.UnitsInStock.ToString();
                        UnitsOnOrder.Text = info.UnitsOnOrder == null ? "" : info.UnitsOnOrder.ToString();
                        ReorderLevel.Text = info.ReorderLevel == null ? "" : info.ReorderLevel.ToString();
                        Discontinued.Checked = info.Discontinued;
                        // moved from info instance that holds the product record to appropriate field on form

                    }
                }
                catch (Exception ex) // need exception ex here to make the (ex) below work
                {
                    errormsgs.Add("File Error: " + GetInnerException(ex).Message); // this displays the error msg instead of us using text like in the IF statement
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                }
            }
            
        }
    }
}