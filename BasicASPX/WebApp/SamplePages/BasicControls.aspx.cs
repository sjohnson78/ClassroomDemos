using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        public static List<DDLClass> DataCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            // this method will execute on EACH and EVERY post back to this page

            // this method will execute on the first display of this page

            // to determine if the page is new or postback, use the IsPostBack property

            // this method is often used as a general method to reset fields or controls at the start of page processing

            // the label MessageLabel is used to display messages to the user. Old messages should be removed from this control on each pass

            // how do we reference a control on the .aspx form? notice that each form control has an ID, we can use this.

            // each control is an object, therefore we will be altering property values

            MessageLabel.Text = "";

            if (!Page.IsPostBack) // "!" means NOT
            {
                // here we are creating an instance of List<T> for the "fake database" data
                DataCollection = new List<DDLClass>();

                // add data to the collection that we just created, one entry at a time
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "DMIT1508"));
                DataCollection.Add(new DDLClass(3, "CPSC1517"));
                DataCollection.Add(new DDLClass(4, "DMIT2018"));

                // one benefit of using a list vs an array is that we can easily sort them, we do this below using the .Sort() method

                // (x, y) represents ANY two entries in the data collection at ANY point in time

                // the lamda symbol "=>" basically means "do the following"

                // .CompareTo() is a mehtod that will compare two items and return the result

                // this result is then interpreted by the Sort() method to determind if the order needs to be changed

                // x vs y is ascending
                // y vs x is descending

                DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

                // place the collection into the dropdownlist
                // a) assign the collection to the control (ID = CollectionList

                CollectionList.DataSource = DataCollection;

                // b) assign the value and display portions of the dropdownlist to specify properties of the data class
                CollectionList.DataTextField = nameof(DDLClass.DisplayField);
                CollectionList.DataValueField = nameof(DDLClass.ValueField);

                // c) bind the data to the collection (aka physical attachment)
                CollectionList.DataBind();

                // d) you may wish to add a prompt line at the beginning of the list of data within the dropdown list

                CollectionList.Items.Insert(0, "select...");
            }
            
        } // closes PageLoad

        // SubmitButtonChoice is the ID of the button on the BasicControls.aspx page
        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "You pressed the Submit Choice button";

            // grab the contents of various controls and manipulate the content of other controls

            // controls have certain properties that can be accessed to obtain and assign values
            // change the .Text property:
            string submitChoice = TextBoxNumberChoice.Text;

            if (string.IsNullOrEmpty(submitChoice))
            {
                MessageLabel.Text = "Your did not enter a number between 1 and 4";
            }
            else
            {
                // RadioButtonList Properties: SelectedIndex, SelectedValue, SelectedItem
                // SelectedIndex returns the physical line index number
                // SelectedValue returns the data value associated with the physical line
                // SelectedItem returns the data display associated with the physical line
            }

        } // closes submitbuttonchoice

        protected void LinkButtonChoice_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "You pressed the Link button";
        }
        
    }
}