using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Northwind.Data.Entities;
using NorthwindSystem.DAL;
using System.ComponentModel; // you need ths here to be able to use [DataObject] below
#endregion

namespace NorthwindSystem.BLL
{
    [DataObject] // make sure to put the "using" above

    public class CategoryController
    {

        // note that you can also do insert update and delete, not just selects. 
        // false here stops it from being set as the default, true would be default
        // there can only be one default of each type (insert, update, delete, select)
        // don likes to set them all as false so that the develop needs to set their own default in the wizard

        // ANY TIME YOU MAKE ANY ALTERATION TO THE BLL OBJECT, IF YOU WANT TO SEE IT IN THE WIZARD, YOU MUST REBUILD YOUR LIBRARY!!!!

        [DataObjectMethod(DataObjectMethodType.Select, false)] 
        
        public List<Category> Categories_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Category Categories_GetCategory(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }
    }
}
