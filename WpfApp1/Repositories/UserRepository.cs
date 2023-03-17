using ComputerGraphics.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User] WHERE username=@username AND email=@email AND [password]=@password";
                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = credential.UserName;
                //command.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = credential.Email;
                command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
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
                command.CommandText = "SELECT * FROM [User] WHERE username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            UserName = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            Email = reader[4].ToString(),
                        };
                    }
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
