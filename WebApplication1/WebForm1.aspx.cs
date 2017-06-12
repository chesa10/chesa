using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Extract Class
        ExtractFile file;
        // person class
        Person person;

        // an array to hold lines from person file
        string[] persons = new string[11];

        // this variable is increamented on every button click of import, to go the next line of the file
        public int nextImport
        {
            get
            {
                if (ViewState["pcounter"] != null)
                {
                    return ((int)ViewState["pcounter"]);
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                ViewState["pcounter"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a person object
            person = new Person();
            // create extractfile object and pass it a filepath
            file = new ExtractFile(Server.MapPath("Person.csv").ToString());

        }

        // triggered by save button
        protected void save_click(object sender, EventArgs e)
        {
            // Check if important controls are valid before saving
            if (vId.IsValid && vFirstN.IsValid && vFirstN2.IsValid && vLastN.IsValid && vLastN2.IsValid && vAge.IsValid && vAge2.IsValid && vSex.IsValid && vSex2.IsValid && vMobi.IsValid && vActive.IsValid && vActive2.IsValid)
            {
                msg.Text = person.Msg;

                // call a save method
                person.SaveRecord(int.Parse(id1.Text), firstN.Text, lastN.Text, int.Parse(age.Text), sex.Text, mobile.Text, active.Text);
                // call clear control method
                ClearControls();
                // display a messsage
                msg.Text = person.Msg;

            }
            else
            {
                msg.Text = "We could not save your data";
            }
       
        }

        // triggered by view button
        protected void view_click(object sender, EventArgs e)
        {
            // Clear any displayed messages
            msg.Text = "";

            if (vId.IsValid && id1.Text.Length > 0)
            {
                int ID = int.Parse(id1.Text);
                // Call view record method
                SqlDataReader rd = person.ViewRecord(ID);
                rd.Read();
                // display retrieved data to the controls
                if(rd.HasRows)
                {
                    firstN.Text = rd.GetString(1);
                    lastN.Text = rd.GetString(2);
                    age.Text = rd.GetInt32(3).ToString();
                    sex.Text = rd.GetString(4);
                    mobile.Text = rd.GetString(5);
                    active.Text = rd.GetString(6);

                    // assing a new message
                    msg.Text = "Here is your requested record";
                    //Close database and datareader
                    rd.Close();
                    person.con.Close();
                }
                else
                {
                    msg.Text = "We could not find the record of the specified Id";
                    //Close database and datareader
                    rd.Close();
                    person.con.Close();
                }
                
            }

        }

        // triggered by clear button
        protected void clear_click(object sender, EventArgs e)
        {
            ClearControls();
        }

        // triggered by delete button 
        protected void delete_click(object sender, EventArgs e)
        {
            //initialize message label
            msg.Text = "";

            // check if an id is valid
            if (vId.IsValid && id1.Text.Length > 0)
            {
                // call delete record method
                if (person.DeleteRecord(int.Parse(id1.Text)) == 1)
                {
                    // assing a message
                    msg.Text = "Record deleted successfully";
                }
                else
                {
                    // assing a message
                    msg.Text = "We could not find the record you want to delete";
                }
                //call clear controls method
                ClearControls();
            }
        }

        // triggered by import button
        protected void import_click(object sender, EventArgs e)
        {
            if (file.IsFileOpen)
            {
                if (nextImport < file.persons.Length - 1)
                {
                    file.Import(nextImport);

                    // assign controls
                    id1.Text = file.Id.ToString();
                    firstN.Text = file.FirsN;
                    lastN.Text = file.LastN;
                    age.Text = file.Age.ToString();
                    sex.Text = file.Sex;
                    mobile.Text = file.Mobile;
                    active.Text = file.Active;

                    // increament this variable so that we can go to the next line of the file
                    nextImport++;
                }
                else
                {
                    // if we reach the end of the file, start over
                    nextImport = 0;
                }
            }
            else
            {
                msg.Text = file.Msg;
            }
        }

        // get information about the site
        protected void inFor_click(object sender, EventArgs e)
        {
            msg.Text = "(Next Import) button import person file line by line into the textboxes<br>";
            msg.Text += "(Save to database button) button save the imported line to the database<br>";
            msg.Text += "(Delete) button delete a record of the specified id from the database<br>";
            msg.Text += "(view from database) button retrieve a record of the specified id from the database<br>";
        }

        // Clear Controls
        private void ClearControls()
        {
            id1.Text = "";
            firstN.Text = "";
            lastN.Text = "";
            age.Text = "";
            sex.Text = "";
            mobile.Text = "";
            active.Text = "";
            
        }
    }
}