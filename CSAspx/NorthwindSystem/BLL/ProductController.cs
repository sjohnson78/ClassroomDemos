
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Northwind.Data.Entities;
using NorthwindSystem.DAL;
#endregion

namespace NorthwindSystem.BLL
{
    //this is the public interface class that will handle
    //  web page service requests for data to the Product sql table
    //Methods in this class can interact with the internal DAL Context class
    public class ProductController
    {
        //this method will return all records from the sql table Products
        //this will first create a transaction code block which uses
        //    the DAL Context class
        //the Context class has a DbSet<Product> property for referencing
        //    the sql table
        //The property works with EntityFramework to retrieve the data
        public List<Product> Products_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }

        //this method will return a specific record from the sql
        //    Products table based on the primary key
        public Product Products_GetProduct(int productid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productid);
            }
        }
        // // // //
        // INSERT
        // // // //

        // this method will add a new product to the sql product table using the EntityFramework
        // optinally, one can pass back the new IDENTITY value from the successful add

        public int Products_Add(Product newproduct)
        {
            // start the insert transaction, USING is used for transactions, either everything within the using code block works or nothing works
            using(var context = new NorthwindContext())
            {
                // STAGING
                //  stage the new record to the DbSet<T> for the object instance
                //  at this time, the record IS NOT YET physically on the database
                context.Products.Add(newproduct); // this does the staging

                // COMMIT
                //  commit the record to the database
                //  any entity validation is done at this time

                // if this statement is NOT executed, the insert is NOT completed (aka rollback)

                // if this statement is executed but FAILS for some reason, the inster is NOT completed (rollback)

                // if this statement is executed AND is successful, THEN the instert has physically placed the record on the database.
                //      at this time, you can retrieve the new IDENTITY value

                context.SaveChanges();

                // after the success of the SaveChanges() you can access your instance for the new IDENTITY value
                //      this is OPTIONAL, this would be void and would have no return statement if you don't care about the identity
                return newproduct.ProductID;

            }
        }

        // // // //
        // UPDATE
        // // // //

        // this method updates the database, and returns the number of records impacted

        public int Products_Update(Product item)
        {
            // start transaction with "using"
            using(var context = new NorthwindContext())
            {
                // stage
                context.Entry(item).State = System.Data.Entity.EntityState.Modified; //system.data.entity is set in our references

                // commit
                return context.SaveChanges();
            }
        }

        // // // //
        // DELETE
        // // // //

        // this method deletes a record from the database OR this method logically flags a record as "deleted" from the database
        // this method returns the number of records impacted
        // two different versions, physical delete and logical delete

        public int Products_Delete(int productid)
        {
            // start transaction with "using"
            using (var context = new NorthwindContext())
            {
                // // // // // // //
                // PHYSICAL DELETE
                // // // // // // //
                //var existing = context.Products.Find(productid);

                //// stage
                //context.Products.Remove(existing);

                //// commit 
                //return context.SaveChanges();


                // // // // // //
                // LOGICAL DELETE
                // // // // // // 

                // note that a logical delete is just an update to a specific

                // create a variable to represent the existing record
                var existing = context.Products.Find(productid);

                // alter the data value on the record that will logically deem the record deleted.
                // you should NOT rely on the user to do this alteration on the web form

                existing.Discontinued = true;

                // stage
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;

                // commit
                return context.SaveChanges();


            }
        }


    } // CLOSES CLASS
}
