
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional namespaces

using Northwind.Data.Entities; // for "<Category>"
using NorthwindSystem.DAL; // for "NorthwindContext()"



#endregion

namespace NorthwindSystem.BLL
{
    public class CategoryController
    {
        // <Category> is the name of the entity
        // see NorthwindContext.cs for infor on what's being used here
        //      Category is a data definition, Categories is a property
        public List<Category> Category_List() 
        {

            using (var context = new NorthwindContext())
            {
                
                return context.Categories.ToList();  
            }


        }

        // this second mehtod will return a specific record from the Products table, based on the PRIMARY KEY

        public Category Categories_GetCategories(int categoryid) // we are passing in an int, specifically the product id
        {
            // using keyword starts a transaction, anything within is either ALL done or else rolled back
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }
    }
}
