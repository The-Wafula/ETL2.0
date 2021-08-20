using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

using Microsoft.VisualBasic.FileIO;

namespace ETL_2
{
    class Program
    {
        public static string connectStat;
        public static int count = 0;
       // public string[] parsed2;
        //private MySqlConnection conn;

        public static void Main(string[] args)
        {
   

            /////////////////decrypting//////////////////////
            var customerPath = @"C:\Users\USER\Documents\GitHub\SUNAMI SOLAR TRAINING PROJECT\SUNAMI-SOLAR-TRAINING-PROJECT\Project 2_3\customers-encrypted.csv";
            var devicesPath = @"C:\Users\USER\Documents\GitHub\SUNAMI SOLAR TRAINING PROJECT\SUNAMI-SOLAR-TRAINING-PROJECT\Project 2_3\devices-encrypted.csv";

            Console.WriteLine("Hi! Please choose file path to decrypt");// propmpts user to pick file to decrypt
            var path = Console.ReadLine();
            if (path == "c")
            { path = customerPath; }
            else if (path == "d")
            { path = devicesPath; }


            var encodedData = getPathdata(path);
            var decoded = Decoded(encodedData);
            Console.WriteLine("decoded data\n" + decoded);
            ////////////////////////done decrypting//////////////////////////////

            //////text parsing/////////////////////////

            //  string[] parsed = decoded.Split(',', Environment.NewLine);
 string[] parsed = decoded.Split('\n');
            //string[] parsed = decoded.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (string i in parsed)
            {
                Console.WriteLine(i);
                string[] parsed2 = i.Split(',');

                foreach (string j in parsed2)
                  
                {
                    count++;
                    Console.WriteLine("count"+ count + ": "+ j);

                }
                }
          //  Console.WriteLine(parsed2[3]);
       
            // Console.WriteLine(decoded.Split(new[] { Environment.NewLine }, StringSplitOptions.None));



         //  ConnectDb();
            ConnectDb2();
            Console.WriteLine(connectStat);





            //start of db insert 



            // end of db crearion


        }

        public static void ConnectDb2()//fetches encoded file content
        {
      
          //  myConnectionString = "server=127.0.0.1;uid=root;" + "pwd=beee002j2011;database=testdb;";
            //var sql = "INSERT INTO customers(fname, lname, phone) VALUES(@FirstName, @SecondName,@Phone)";

            string dbConnectionString = "server=127.0.0.1;uid=root;" + "pwd=beee002j2011;database=testdb;";
            using (MySqlConnection connection = new MySqlConnection(dbConnectionString))
            {
                string sql = "INSERT INTO customers(fname, lname, phone) VALUES(@FirstName, @SecondName,@Phone)";
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {

                    connection.Open();
                    cmd.Parameters.AddWithValue("@FirstName", "Alex");
                    cmd.Parameters.AddWithValue("@SecondName", "Malik");
                    cmd.Parameters.AddWithValue("@Phone", "0702826107");

                    cmd.ExecuteNonQuery();
                }
            }
        }


        
        public static String getPathdata(String path)//fetches encoded file content
        {
            Console.WriteLine("File Path\n" + path);
            var encodedData = File.ReadAllText(path);
            return encodedData;
        }

        public static String Decoded(String encodedData)//decodes fetched file content now
        {
            byte[] data = System.Convert.FromBase64String(encodedData);
            var decoded = System.Text.UnicodeEncoding.ASCII.GetString(data);
            return decoded;
        }
    }

}
