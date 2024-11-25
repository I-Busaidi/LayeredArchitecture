using LayeredArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        string AddUser(User user);
        string UpdateUser(User user);
        string DeleteUser(int userId);
    }
}
