using System.Data;

namespace TimeTracking.Domain.Models
{
    public class User : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserStatistics UserStatistics { get; set; }
       

        public User()
        {
        }

        public User(string firstName, string lastName, int age, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Username = username;
            Password = password;
          
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string GetInfo()
        {
            return $"User [{FirstName} {LastName}] with username: [{Username}]]";

        }
    }
}
