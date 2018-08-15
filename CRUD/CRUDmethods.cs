using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
 
namespace CRUD
{
    public class CRUDmethods
    {
        private static string connectionString;

        public CRUDmethods(string _connectionString)
        {
            connectionString = _connectionString;
        }

        static List<string> GetProductNames()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT name FROM products;";

                MySqlDataReader dr = cmd.ExecuteReader();

                List<string> productNames = new List<string>();

                while (dr.Read())
                {
                    string name = dr["name"].ToString();
                    productNames.Add(name);
                }

                return productNames;
            }
        }

        //Create
        public void Insert(BestBuyProducts product)
        {
            MySqlConnection conn = new MySqlConnection();

            using (conn)
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO products (Name, Price) " +
                                  "VALUES (@name, @price;";
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);

                cmd.ExecuteNonQuery();
            }
        }

        //Read
        public List<BestBuyProducts> Select()
        {
            MySqlConnection conn = new MySqlConnection();

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT ProductID, Name, Price " +
                                  "FROM products;";

                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<BestBuyProducts> products = new List<BestBuyProducts>();

                while (dataReader.Read())
                {
                    BestBuyProducts product = new BestBuyProducts();
                    product.Id = Convert.ToInt32(dataReader["ProductID"]);
                    product.Name = dataReader["Name"].ToString();
                    product.Price = Convert.ToDouble(dataReader["Price"]);

                    products.Add(product);
                }

                return products;
            }
        }

        //Update
        public void Update(BestBuyProducts product)
        {
            MySqlConnection conn = new MySqlConnection();

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE products " +
                                  "SET Name = @name, Price = @price " +
                                  "WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("id", product.Id);

                cmd.ExecuteNonQuery();
            }
        }

        //Delete
        public void DeleteProduct(int productID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE ProductID = " + productID;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
