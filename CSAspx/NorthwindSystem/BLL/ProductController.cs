
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Northwind.Data.Entities; // needed for "<Product>"
using NorthwindSystem.DAL; // needed for "NorthwindContext()"


#endregion

namespace NorthwindSystem.BLL
{
    // this class is a public interface class that will handle web page service requests for data to the "Products" SQL table
    //      methods in this class can interact with the internal DAL context class
    //      as always, make sure the class is public

    public class ProductController
    {
        // this method will return all records from the Products table
        //      first it will create a transaction code block that uses the DAL Context class
        // the Context class has a DbSet<Product> for referencing the SQL table
        // the property works with EntityFramework to retrieve the data

        public List<Product> Products_List() // this method header states that we will be returning a list
        {
            
            using (var context = new NorthwindContext()) // context is a decent variable name here because this is a context class
            {
                // the single line of code below returns all Products
                return context.Products.ToList();   // this will not return a list, we need to use an extension .ToList() to change it into a list
            }


        }
                
        // this second mehtod will return a specific record from the Products table, based on the PRIMARY KEY

        public Product Products_GetProduct (int productid) // we are passing in an int, specifically the product id
        {
            // using keyword starts a transaction, anything within is either ALL done or else rolled back
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productid);
            }
        }









    }
}
