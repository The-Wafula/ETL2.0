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
        public static void Main(string[] args)
        {





            /////connct to db///////


            /////end of connection   



            //start of db creation
            ///////////////conection code
            string connetionString = null;
            SqlConnection cnn;
             connetionString = "server=localhost;user=root;database=world;port=3306;password=beee002j2011";
            // connetionString = @"Data Source=WIN-50GP30FGO75;Initial Catalog=Demodb;User ID=sa;Password=demol23";
            //connetionString = @"Data Source=127.0.0.1;port=3306;Initial Catalog=users;User ID=root;Password=beee002j2011";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Can not open connection !");
            }


            // end of db crearion


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
