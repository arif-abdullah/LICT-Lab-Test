using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LabTest05.Models;
using LabTest05.Models.ViewModels;

namespace LabTest05.DAL
{
    public class OrderGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["RMSConnectionString"].ConnectionString;

        public int Order(OrderFoodVM orderFood)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Orders(MemberId,FoodItemId,Quantity,OrderDate) VALUES (" + orderFood.MemberId +
                           "," + orderFood.FoodItemId + "," + orderFood.Quantity + ",'" +
                           orderFood.OrderDate.Date.ToString("d") + "');";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Member> GetAllMembers()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM Members;";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Member> members = new List<Member>();
            while (reader.Read())
            {
                Member member = new Member();
                member.Id = (int)reader["Id"];
                member.Code = reader["Code"].ToString();
                member.Name = reader["Name"].ToString();
                member.Email = reader["Email"].ToString();
                member.ContactNo = reader["ContactNo"].ToString();
                member.TypeId = (int) reader["TypeId"];
                members.Add(member);
            }

            reader.Close();
            connection.Close();
            return members;
        }

        public List<FoodItem> GetAllFoodItems()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM FoodItems;";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<FoodItem> foodItems= new List<FoodItem>();
            while (reader.Read())
            {
                FoodItem food = new FoodItem();
                food.Id = (int)reader["Id"];
                food.Name = reader["Name"].ToString();
                food.UnitPrice = (decimal)reader["UnitPrice"];
                
                foodItems.Add(food);
            }

            reader.Close();
            connection.Close();
            return foodItems;
        }

        public List<ItemViewVM> GetItemView(ViewReportVM viewReport)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM Reports WHERE Id = " + viewReport.MemberId + " AND OrderDate = '"+viewReport.OrderDate.Date.ToString("d")+"';";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ItemViewVM> itemList = new List<ItemViewVM>();
            while (reader.Read())
            {
                ItemViewVM item = new ItemViewVM();
                
                item.ItemName = reader["Name"].ToString();
                item.Quantity = (decimal) reader["Quantity"];
                item.TotalPrice = (decimal) reader["Total"];

                itemList.Add(item);
            }

            reader.Close();
            connection.Close();
            return itemList;
        }
        public List<ItemViewVM> GetItemView()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT * FROM Reports;";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ItemViewVM> itemList = new List<ItemViewVM>();
            while (reader.Read())
            {
                ItemViewVM item = new ItemViewVM();

                item.ItemName = reader["Name"].ToString();
                item.Quantity = (decimal)reader["Quantity"];
                item.TotalPrice = (decimal)reader["Total"];

                itemList.Add(item);
            }

            reader.Close();
            connection.Close();
            return itemList;
        }

    }
}