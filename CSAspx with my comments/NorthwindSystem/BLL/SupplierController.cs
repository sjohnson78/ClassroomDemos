
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using Northwind.Data.Entities;
using NorthwindSystem.DAL;

#endregion

namespace NorthwindSystem.BLL
{
    public class SupplierController
    {
        
        // <Category> is the name of the entity
        // see NorthwindContext.cs for infor on what's being used here
        //      Category is a data definition, Categories is a property
        public List<Supplier> Supplier_List()
        {

            using (var context = new NorthwindContext())
            {

                return context.Suppliers.ToList();
            }


        }

        // this second mehtod will return a specific record from the Products table, based on the PRIMARY KEY

        public Supplier Suppliers_GetSuppliers(int supplierid) // we are passing in an int, specifically the product id
        {
            // using keyword starts a transaction, anything within is either ALL done or else rolled back
            using (var context = new NorthwindContext())
            {
                return context.Suppliers.Find(supplierid);
            }
        }        
    }
}
