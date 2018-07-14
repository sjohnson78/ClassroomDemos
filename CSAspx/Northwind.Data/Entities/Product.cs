using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


// having a region for additional namespaces is a best practice that don suggests, it's easier to find missing namespaces
#region Additional Namespaces
using System.ComponentModel.DataAnnotations; // for [Key]
using System.ComponentModel.DataAnnotations.Schema; // use lightbulb dropdown to automatically add this, it's for [Table]


#endregion



namespace Northwind.Data.Entities
{
    // you need a using clause, otherwise you have to fully qualify it every time (aka type the full thing which is stupid)    
    // []Table below has an error at first, hover it, click the lightbulb, select the top option "using..." which will add it to the top

    // the code below is a table annotation, which points to the table in the sql database that this class defines
    // aka this class product represents the products table in the database
    [Table("Products")]

    public class Product // the default access privelige of a class is private, make sure you add public before class
    {
        // we need to create a property for each attribute on the sql table
        // use C# datatypes for the sql attributes
        // rules:
        // a. if you use the attribute name as your property name, then the order of the properties is NOT important (DO IT THIS WAY, DON'T BE STUPID)
        // b. however, if you do not use the attribute name as your property name, the order of properties must match the order of attributes.
        // c. foreign keys do NOT need an annotation of the property name is the same as the attribute name
        // d. primary keys, by default, are treated as an IDENTITY. 
        //      If your PK is not an IDENTITY, then you must add a .DataGenerated(DataGeneratedOption.xxxx) annotation parameter
        // e. primary key properties are best defaulted to end in ID (Id) aka not case sensitive
        // f. compound primary keys are described using the Column(Order=n) annotation parameter;
        //      where n is 1, 2, 3, etc. (physical order of sql attributes)

        //[Key, Column(Order =1)]  // if it's part of a compound PK you need the syntax like this
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity] // this is the default, we can just have it as [Key], if it's not an identity we can put .None


        // best practice here would be to have SQL open, you can check to see if the attributes match your property names, data types, nullable, etc...

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; } // for string you don't need a question mark for nullable
        public int? SupplierID { get; set; } // question mark means nullable 
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; } // some people use a double instead of a decimal
        public decimal? UnitPrice { get; set; }
        public Int16? UnitsInStock { get; set; }
        public Int16? UnitsOnOrder { get; set; }
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }


        // sometimes you'll want another property in your class taht will return a non-attribute value to the user
        //      for example: "Name" which would return first name plus last name
        // to create these non-mapped (aka non-existing SQL attributes) properties, use the annotation [NotMapped] to let the system know you aren't referencing an attribute
        //      for example:

        [NotMapped]
        public string ProductIDName
        {
            get
            {
                return ProductName + " (" + ProductID.ToString() + ")";
            }
        }










    }
}
