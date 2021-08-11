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
            string[] parsed = decoded.Split(Environment.NewLine,
                              StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in parsed)
            {
                System.Console.WriteLine($"<{word}>");
            }
            ConnectDb();
            Console.WriteLine(connectStat);

            //start of db creation



            // end of db crearion


        }

        public static String ConnectDb()//fetches encoded file content
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
       

            myConnectionString = "server=127.0.0.1;uid=root;" + "pwd=beee002j2011;database=world;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();
                connectStat = "Succesfull connection!";
                return connectStat;
               // conn.Close();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                connectStat="Can not open connection !";
                return connectStat;
            }
        }

        public static String getPathdata(String path)//fetches encoded file content
        {
            Console.WriteLine("File Path\n" + path);
            var encodedData = File.ReadAllText(path);
            return encodedData;
        }

        public static String Decoded(String encodedData)//decodes fetched file content
        {
            byte[] data = System.Convert.FromBase64String(encodedData);
            var decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
            return decoded;
        }
    }

}
