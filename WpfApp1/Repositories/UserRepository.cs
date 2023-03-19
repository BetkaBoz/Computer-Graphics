using ComputerGraphics.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerGraphics.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [User] (UserName, Email, Password) VALUES (@UserName, @Email, @Password)", connection);
                command.Parameters.AddWithValue("@UserName", userModel.UserName);
                command.Parameters.AddWithValue("@Email", userModel.Email);
                command.Parameters.AddWithValue("@Password", userModel.Password);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0) Debug.WriteLine("User registration successful.");
                else Debug.WriteLine("User registration failed.");
            }
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User] WHERE UserName=@UserName AND [Password]=@Password";
                command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }
        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUserName(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User] WHERE UserName=@UserName";
                command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            UserName = reader[1].ToString(),
                            Email = reader[2].ToString(),
                            Password = string.Empty,
                            Lecture = reader[2].ToString(),
                        };
                    }
                }
            }
            return user;
        }
    }
}
