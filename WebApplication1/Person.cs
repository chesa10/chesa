using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public class Person
    {
        public SqlConnection con;

        // Class members
        private string msg;
        public string Msg { get { return msg; } }

        public Person()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
        }



        // save a record into the database
        public void SaveRecord(int id, string firstN, string lastN, int age, string sex, string mobile, string active)
        {
            try
            {
                con.Open();
                SqlCommand cmd;
                SqlDataReader rd;

                // Check if an id exist before inserting
                string q = "select * from person where id = @id";
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@id", id);
                rd = cmd.ExecuteReader();
                bool hasRows = rd.HasRows;
                rd.Close();

                // if an id does not exist save else update the record
                if (!hasRows)
                {
                    q = "insert into Person (id, firstName, lastName, age, sex, mobile, active) values (@id, @firstName, @lastName, @age, @sex, @mobile, @active)";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@firstName", firstN);
                    cmd.Parameters.AddWithValue("@lastName", lastN);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@mobile", mobile);
                    cmd.Parameters.AddWithValue("@active", active);

                    cmd.ExecuteNonQuery();

                    msg = "Data saved sucessfully";
                }
                else
                {
                    string query = @"update Person
                         set firstName = @firstName, lastName = @lastName, age = @age, sex = @sex, mobile = @mobile, active = @active
                         where id = @id";
                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@firstName", firstN);
                    cmd.Parameters.AddWithValue("@lastName", lastN);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@mobile", mobile);
                    cmd.Parameters.AddWithValue("@active", active);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                    msg = "Data updated sucessfully";
                }
            }
            catch (Exception Ex)
            {
                msg = Ex.ToString();
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        //delete a record from the database
        public int DeleteRecord(int id)
        {
            try
            {

                con.Open();
                string q = "delete from person where id = @id";
                SqlCommand cmd = new SqlCommand(q, con);

                cmd.Parameters.AddWithValue("@id", id);
               return cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        //view record 
        public SqlDataReader ViewRecord(int id)
        {
            SqlDataReader rd = null;
            try
            {
                con.Open();
                string q = "select id,firstName,lastName,age,sex,mobile,active from person where id= @id";
                SqlCommand cmd = new SqlCommand(q, con);

                cmd.Parameters.AddWithValue("@id", id);

                rd = cmd.ExecuteReader();

                return rd;
            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());
                return rd;
            }
            finally
            {
               // con.Close();
            }
        }
    }
}