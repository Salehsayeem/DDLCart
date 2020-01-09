using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DropDownListCart.Models;

namespace DropDownListCart.DAL
{
    public class ItemGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        internal string SaveItem(Item aItem)
        {
            //Query for Inserting items
            string query = "INSERT INTO Item Values (@Name, @Price,@Quantity)";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("Code", SqlDbType.VarChar);
            command.Parameters["Name"].Value = aItem.Name;

            command.Parameters.Add("Price", SqlDbType.Int);
            command.Parameters["Price"].Value = aItem.Price;

            command.Parameters.Add("Quantity", SqlDbType.Int);
            command.Parameters["Quantity"].Value = aItem.Quantity;
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
                return "Saved";
            return "Failed";
        }

        internal List<Item> getAllItems()
        {
            string query = "SELECT * FROM Item";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Item> itemList = new List<Item>();
            while (reader.Read())
            {
                itemList.Add(new Item
                {
                    Name = reader["Name"].ToString(),
                    Price = Convert.ToInt32(reader["Price"]),
                    Quantity = Convert.ToInt32(reader["Quantity"])

                });
            }
            reader.Close();
            connection.Close();
            return itemList;
        }
    }
}