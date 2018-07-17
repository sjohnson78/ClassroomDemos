using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

using System.Data.Entity; // for internal class NorthwindContext:DbContext
using Northwind.Data.Entities; // for public DbSet<Product> Products { get; set; }

#endregion

namespace NorthwindSystem.DAL
{
    // to add some security to the database access, we will set the access privelige of this class to INTERNAL.
    //      this access resticts calls to this class from within this project only, aka the only way you can call this class is if you are inside the project

    // this class will be created by any BLL controller class method

    // this class will interact with the EntityFramework software to access the database.
    //      to setup this interaction, this clas will inherit from EntityFramework its DbContext class ":DbContext" below

    internal class NorthwindContext:DbContext
    {
        // we need to pass the database connection to the EntityFramework DbContext class via the :base("xxxx") parameter
        // this is done via the NorthwindContext constructor

        public NorthwindContext() : base("NWDB")
        {

        }

        // indicate the property in this context class that will connect the sql table to the data definition class
        // this is done by using the DbContext datatype DbSet<T> where <T> is the data definition class

        // Product is the data definition
        // Products is the property of the context class  
        // DbSet is an EntityFramework data type (note it's a plural this time)
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
