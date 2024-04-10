

using GenericMethods.Domain.Models.BaseModel;

namespace GenericMethods.Domain.Models
{
    public class Fish : Pet
    {
        public string Color { get; set; }
        public string Size { get; set; }


        public Fish(string name, string type, int age, string color, string size)
        {
            Name = name;
            Type = type;
            Age = age;
            Color = color;
            Size = size;
        }

        public override void PrintInfo()
        {
            Console.WriteLine( $"Name: {Name}, Type: {Type}, Age: {Age}, Color: {Color}, Size: {Size}");
        }

    }
}
