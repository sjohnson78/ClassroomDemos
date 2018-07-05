using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class DDLClass
    {
        // to add another class, right click webapp (root folder, project not solution), add, class
        public int ValueField { get; set; }
        public string DisplayField { get; set; }
        public DDLClass()
        {

        }
        public DDLClass(int valuefield, string displayfield)
        {
            ValueField = valuefield;
            DisplayField = displayfield;
        }
    }
}