using LayeredArchitecture.Models;
using LayeredArchitecture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public string AddUser(User user)
        {
            var userToCheck = GetUserByEmail(user.Email);
            if (userToCheck == null)
            {
                _userRepository.AddUser(user);
                return "User added successfully.";
            }
            else
            {
                return "User with this email already exists.";
            }
        }

        public string UpdateUser(User user)
        {
            var userToCheck = GetUserByEmail(user.Email);
            if (userToCheck == null || GetUserById(user.Id).Email == user.Email)
            {
                _userRepository.UpdateUser(user);
                return "User updated successfully.";
            }
            else
            {
                return "A user with this email already exists.";
            }
            
        }

        public string DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                _userRepository.DeleteUser(userId);
                return "User deleted successfully.";
            }
            else
            {
                return "User could not be found.";
            }
        }
    }
}
