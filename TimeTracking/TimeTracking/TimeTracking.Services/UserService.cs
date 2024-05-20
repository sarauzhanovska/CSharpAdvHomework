using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Domain.Models;
using TimeTracking.Helpers;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public User CurrentUser { get; set; }
              

        public bool Login(string username, string password)
        {
            User userDb = GetAll().SingleOrDefault(u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && u.Password == password);
            if (userDb is null)
            {
                throw new Exception("Login failed! Invalid credentials entered!");
            }
            CurrentUser = userDb;
            return true;
        }
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (CurrentUser.Password != oldPassword || !ValidationHelper.IsPasswordValid(newPassword) || oldPassword == newPassword)
            {
                return false;
            }
            CurrentUser.Password = newPassword;
            return Update(CurrentUser);
        }

        public void Register(string firstName, string lastName, int age, string username, string password)
        {
            bool userExists = GetAll().Any(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (userExists)
            {
                throw new Exception("User already exists!");
            }
            User newUser = new User(firstName,lastName, age, username, password);
            Insert(newUser);
        }

        public bool ChangeFirstName(string oldFirstName, string newFirstName)
        {
            if (CurrentUser.FirstName != oldFirstName || !ValidationHelper.IsNameValid(newFirstName) || oldFirstName == newFirstName)
            {
                return false;
            }
            CurrentUser.FirstName = newFirstName;
            return Update(CurrentUser);
        }

        public bool ChangeLastName(string oldLastName, string newLastName)
        {
            if (CurrentUser.FirstName != oldLastName || !ValidationHelper.IsNameValid(newLastName) || oldLastName == newLastName)
            {
                return false;
            }
            CurrentUser.LastName = newLastName;
            return Update(CurrentUser);
        }
        public void Logout()
        {
            CurrentUser = null;
            ExtendedConsole.PrintSuccess("Logged out successfully!");
        }

    }
}
