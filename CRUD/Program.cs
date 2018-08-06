using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What color products do you want to see?");

            string response = Console.ReadLine();

            List<string> values = GetProductNames(response);

            foreach (string value in values)
            {
                Console.WriteLine(value);
            }
            Console.ReadLine();
        }

        static List<string> GetProductNames(string color)
        {
            string connStr = "Server=localhost;Database=bestbuy;Uid=root;Pwd=johnpaulgreer;SslMode=None;";

            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Name FROM product WHERE color ='" + color + "';";

                MySqlDataReader dr = cmd.ExecuteReader();

                List<string> productNames = new List<string>();

                while (dr.Read())
                {
                    productNames.Add(dr["Name"].ToString());
                }

                return productNames;
            }
        }

        static void Delete()
        {
            string connStr = "Server=localhost;Database=bestbuy;Uid=root;Pwd=johnpaulgreer;SslMode=None;";

            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM productreview WHERE reviewername = 'David';";

                cmd.ExecuteNonQuery();
            }
        }

        static void Create()
        {
            string connStr = "Server=localhost;Database=bestbuy;Uid=root;Pwd=johnpaulgreer;SslMode=None;";

            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO productreview ();";

                cmd.ExecuteNonQuery();
            }
        }

        //static void Read()
        //{
        //    string connStr = "Server=localhost;Database=bestbuy;Uid=root;Pwd=johnpaulgreer;SslMode=None;";

        //    MySqlConnection conn = new MySqlConnection(connStr);

        //    using (conn)
        //    {
        //        conn.Open();

        //        MySqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "DELETE FROM productreview WHERE reviewername = 'David';";

        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}
