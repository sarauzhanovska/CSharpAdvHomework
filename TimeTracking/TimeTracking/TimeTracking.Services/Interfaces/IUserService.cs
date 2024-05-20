

using TimeTracking.Domain.Models;

namespace TimeTracking.Services.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        User CurrentUser { get; set; }
        bool Login(string username, string password);
        bool ChangeFirstName (string oldFirstName, string newFirstName);
        bool ChangeLastName (string oldLastName, string newLastName);
        bool ChangePassword(string oldPassword, string newPassword);
        void Register(string firstName, string lastName, int age, string username, string password);
        void Logout();


    }
}
