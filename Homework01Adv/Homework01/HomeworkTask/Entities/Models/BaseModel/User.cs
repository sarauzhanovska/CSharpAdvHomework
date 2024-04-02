using HomeworkTask.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask.Entities.Models.BaseModel
{
    public abstract class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }


        public User (int id, string name, string username)
        {
            Id = id;    
            Name = name;
            Username = username;
        }

        public abstract string PrintUser();
        
    }
}
