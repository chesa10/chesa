using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApplication1
{
    public class ExtractFile
    {
        // an array to be populated with data from the file
        public string[] persons = new string[11];

        // Class members;
        private bool isFileOpen = true;
        public bool IsFileOpen { get { return isFileOpen; } }

        private string msg;
        public string Msg { get { return msg; } }


        private int id;
        public int Id { get { return id; } }

        private string firstN;
        public string FirsN { get { return firstN; } }

        private string lastN;
        public string LastN { get { return lastN; } }

        private int age;
        public int Age { get { return age; } }

        private string sex;
        public string Sex { get { return sex; } }

        private string mobile;
        public string Mobile { get { return mobile; } }

        private string active;
        public string Active { get { return active;} }


        public ExtractFile(string filePath)
        {

            try
            {

                StreamReader reader = new StreamReader(filePath);
                string fi = reader.ReadLine();
                int count = 0;

                while (fi != null)
                {
                    fi = reader.ReadLine();
                    persons[count] = fi;
                    count++;
                }
            }
            catch (Exception Ex)
            {
                isFileOpen = false;
                Console.WriteLine(Ex.ToString());
            }

        }

        // This the person.csv file line by line
        public void Import(int nextLine)
        {

            if (isFileOpen)
            {
                string per = persons[nextLine];
                // append comma(,) to end of the string if it does not exist before spliting
                if (per[per.Length - 1].ToString() != ",")
                {
                    per += ",";
                }

                //n.Text = persons[i];
                string[] person = per.Split(',');

                id = int.Parse(person[0]);
                firstN = person[1];
                lastN = person[2];

                // int y = 3;
                for (int y = 3; y < person.Length - 1; y++)
                {


                    if (person[y].Length == 2)
                    {
                        age = int.Parse(person[y]);
                    }
                    else if (person[y].Length == 1)
                    {
                        sex = person[y];
                    }
                    else if (person[y].Length > 2 && person[y].Length < 6)
                    {
                        active = person[y];
                    }
                    else
                    {
                        mobile = person[y];
                    }
                }
            }
            else
            {
                msg = "I could not open the file";
            }


        }

    }
}