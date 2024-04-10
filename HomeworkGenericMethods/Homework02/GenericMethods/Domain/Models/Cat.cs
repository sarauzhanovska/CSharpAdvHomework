

using GenericMethods.Domain.Models.BaseModel;
using System;

namespace GenericMethods.Domain.Models
{
    public class Cat : Pet
    {

        public bool IsLazy { get; set; }
        public int LivesLeft { get; set; }

        public Cat(string name,string type, int age, bool isLazy, int livesLeft)
        {
            Name = name;
            Type = type;
            Age = age;
            IsLazy = isLazy;
            LivesLeft = livesLeft;
        }


        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Type: {Type}, Age: {Age}, Is Lazy: {IsLazy}, Lives Left: {LivesLeft}");
        }
    }
}
