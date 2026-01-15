using Bloggy.Demo.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Bloggy.Demo
{
    public class DataAccess
    {
        // "Server=(localdb)\\mssqllocaldb;Database=users;Trusted_Connection=True"

        //private const string connectionString = "Server=(localdb)\\mssqllocaldb; Database=BlogPostDemo";
        //private const string connectionString = @"Server=(localdb)\mssqllocaldb; Database=BlogPostDemo";

        // "Server=(localdb)\\mssqllocaldb;Database=users;Trusted_Connection=True"

        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BlogPostDemo;Trusted_Connection=True;Integrated Security=True";
        //private const string connectionString  = "Server=(localdb)\\mssqllocaldb;Integrated Security=True;Trusted_Connection=True";

 
        public void InitDatabase()
        {
            string basePath = AppContext.BaseDirectory;
            string scriptPath = Path.Combine(basePath, "SqlScripts", "Recreate.sql");
            //string recreateDb = File.ReadAllText(scriptPath);
            // string recreateDb = "CREATE DATABASE BlogPostDemo";
            string recreateDb = "CREATE TABLE BlogPost (Id INT IDENTITY(1, 1) PRIMARY KEY, Title NVARCHAR(50) NULL, Author NVARCHAR(50) NULL,)";

            
            scriptPath = Path.Combine(basePath, "SqlScripts", "Insert.sql");
            string insertDb = File.ReadAllText(scriptPath);
            scriptPath = Path.Combine(basePath, "SqlScripts", "Select.sql");
            string selectDb = File.ReadAllText(scriptPath);

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(recreateDb, connection);
            connection.Open();
            command.ExecuteNonQuery();

            command = new SqlCommand(insertDb, connection);
            command.ExecuteNonQuery();
            command = new SqlCommand(selectDb, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var bp = new BlogPost
                {
                    Id = reader.GetSqlInt32(0).Value,
                    Author = reader.GetSqlString(1).Value,
                    Title = reader.GetSqlString(2).Value
                };
            }
        }

        public List<BlogPost> GetAllBlogPostsBrief()
        {
            string sqlString = "SELECT Id, Author, Title FROM BlogPost";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BlogPost> blogPosts = new List<BlogPost>();
            while (reader.Read())
            {
                BlogPost post = new BlogPost
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Author = reader["Author"].ToString(),
                    Title = reader["Title"].ToString()
                };

                blogPosts.Add(post);
            }
            reader.Close();
            connection.Close();
            return blogPosts;
        }


        public BlogPost GetPostById(int postId)
        {
            string sqlString = "SELECT Id, Author, Title FROM BlogPost WHERE Id = @Id";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@Id", postId);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BlogPost post = null;
            if (reader.Read())
            {
                post = new BlogPost
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Author = reader["Author"].ToString(),
                    Title = reader["Title"].ToString()
                };
            }
            reader.Close();
            connection.Close();
            return post;
        }

        public void AddBlogPost(BlogPost blogPost) {             
            string sqlString = "INSERT INTO BlogPost (Author, Title) VALUES (@Title, @Author)";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@Title", blogPost.Title);
            command.Parameters.AddWithValue("@Author", blogPost.Author);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateBlogPost(BlogPost blogPost)
        {
            string sqlString = "UPDATE BlogPost SET Title = @Title, Author = @Author WHERE Id = @Id";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@Id", blogPost.Id);
            command.Parameters.AddWithValue("@Title", blogPost.Title);
            command.Parameters.AddWithValue("@Author", blogPost.Author);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeletePostById(int postId)
        {
            string sqlString = "DELETE FROM BlogPost WHERE Id = @Id";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@Id", postId);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
