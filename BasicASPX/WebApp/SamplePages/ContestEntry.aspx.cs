using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
<<<<<<< HEAD
        protected void Page_Load(object sender, EventArgs e)
        {

        }
=======
        // since we are not currently using a database, we will collect the entries into a list<T> collection
        // <T> will be the class entry
        // the List<T> will be static so that it will hang around during our testing

        public static List<Entry> contestentries = new List<Entry>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            EmailAddress.Text = "";
            PostalCode.Text = "";
            Province.SelectedIndex = 0;
            Terms.Checked = false;
            CheckAnswer.Text = "";
        }

        // each control is an object, interact with it's PROPERTIES to change stuff
        
        protected void Submit_Click(object sender, EventArgs e)
        {
            // on the server side, we can rerun the validation controls:

            if (Page.IsValid) // checks for validation = true
            {
                


                string firstName = FirstName.Text;
                string lastName = LastName.Text;
                string streetAddress1 = StreetAddress1.Text;
                string streetAddress2 = StreetAddress2.Text;
                string city = City.Text;
                string email = EmailAddress.Text;
                string pc = PostalCode.Text;
                string province = Province.SelectedValue; // use .SelectedValue for drop down lists
                bool terms = Terms.Checked; // for a bool use .Checked
                string answer = CheckAnswer.Text;


                // there may be validation taht cannot be done using the basic validation controls
                // or there may be a need for logic-based control validation

                if(terms) // how is this working? 
                {
                    // create an instance of the entry using the greedy constructor
                    Entry theEntry = new Entry(firstName, lastName, streetAddress1, streetAddress2, city, province, pc, email);

                    // add this instance to the collection of entries
                    contestentries.Add(theEntry);

                    // attach the collection of entries to the GridView control
                    ContestEntries.DataSource = contestentries; // contestentries is the name of the List<T> we created above
                    ContestEntries.DataBind(); // what does databind do?
                }
                else
                {
                    Message.Text = "You did not agree to the terms of the contest. Entry denied.";
                }

                
            }


            

        }

        
>>>>>>> 806decc385315da31f01e65075d47050f85baa7e
    }
}