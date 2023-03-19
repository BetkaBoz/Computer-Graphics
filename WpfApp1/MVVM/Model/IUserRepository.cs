using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics.MVVM.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        UserModel GetById(int id);
        UserModel GetByUserName(string username);
        IEnumerable<UserModel> GetByAll();
    }
}
