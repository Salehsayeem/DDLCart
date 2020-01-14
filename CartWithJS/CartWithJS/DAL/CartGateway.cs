using CartWithJS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CartWithJS.DAL
{

    public class CartGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        internal string SaveCart(Cart aCart)
        {
            string query = "INSERT INTO Cart Values(@Name,@Price,@Quantity)";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = aCart.Name;

            command.Parameters.Add("Quantity", SqlDbType.VarChar);
            command.Parameters["Quantity"].Value = aCart.Quantity;

            command.Parameters.Add("Price", SqlDbType.VarChar);
            command.Parameters["Price"].Value = aCart.Price;

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
                return "Saved";
            return "Failed";
        }
        internal List<Cart> GetAllCarts()
        {
            string query = "SELECT * FROM Cart";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Cart> cartList = new List<Cart>();
            while (reader.Read())
            {
                cartList.Add(new Cart
                {
                    Name = reader["Name"].ToString(),
                    //Quantity = Convert.ToInt32(reader["Quantity"]),
                    Quantity = reader["Quantity"].ToString(),
                    Price = reader["Price"].ToString()
                    //Price = Convert.ToInt32(reader["Price"])

                });
            }
            reader.Close();
            connection.Close();
            return cartList;
        }
    }
}