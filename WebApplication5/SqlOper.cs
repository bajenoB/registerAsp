using System;
using System.Data.SqlClient;
namespace WebApplication5
{
    public class SqlOperations
    {
        static SqlConnection connection;
        static SqlCommand command;
        public SqlOperations()
        {
            connection = Connection.GetConnection();
            command = new SqlCommand();
        }
        public bool isLoginExist(string login)
        {
            using (command = new SqlCommand($"SELECT * FROM [Users] WHERE [Login] = '{login}'", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return true;
                }
            }
            return false;
        }
        public bool isEmailExist(string email)
        {
            using (command = new SqlCommand($"SELECT * FROM [Users] WHERE [Email] = '{email}'", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return true;
                }
            }
            return false;
        }
        public string Register(string login, string email, string password)
        {
            try
            {
                using (command = new SqlCommand($"INSERT INTO [Users] VALUES('{login}', '{email}', '{password}')", connection))
                {
                    command.ExecuteNonQuery();
                }
                return "Succes!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public bool CheckAuthorization(string login, string password)
        {
            using (command = new SqlCommand($"SELECT * FROM [Users] WHERE [Password] = '{password}' AND [Login] = '{login}'", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return true;
                }
            }
            return false;
        }
    }
}