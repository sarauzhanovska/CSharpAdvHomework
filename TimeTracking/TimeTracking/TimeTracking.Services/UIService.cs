using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Domain.Models;
using TimeTracking.Helpers;
using TimeTracking.Services.Enums;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services
{
    public class UIService : IUIService
    {
        public List<MenuChoice> MenuItems { get ; set ; }
        public User LoginMenu()
        {
            Console.Clear();
            ExtendedConsole.PrintInColor("\nEnter your credentials:", ConsoleColor.Cyan);
            string username = ExtendedConsole.GetInput("Username: ");
            string password = ExtendedConsole.GetInput("Password: ");
            if (!ValidationHelper.ValidateStringInput(username) || !ValidationHelper.ValidateStringInput(password))
            {
                throw new Exception("Please enter valid inputs!");
            }
            return new User()
            {
                Username = username,
                Password = password
            };
        }

        public User RegisterMenu()
        {
            Console.Clear();
            ExtendedConsole.PrintInColor("\nEnter your credentials to register: ", ConsoleColor.DarkMagenta);
            string firstNameRegister = ExtendedConsole.GetInput("First Name: ");
            string lastNameRegister = ExtendedConsole.GetInput("Last Name: ");
            int ageRegister = ExtendedConsole.GetInputInt("Age: ");
            string usernameRegister = ExtendedConsole.GetInput("Username: ");
            string passwordRegister = ExtendedConsole.GetInput("Password: ");
            if(!ValidationHelper.IsNameValid(firstNameRegister) || !ValidationHelper.IsNameValid(lastNameRegister) || !ValidationHelper.IsAgeValid(ageRegister) || !ValidationHelper.IsUsernameValid(usernameRegister) || !ValidationHelper.IsPasswordValid(passwordRegister))
            {
                throw new Exception("Please enter valid inputs!");
            }
            return new User()
            {
                FirstName = firstNameRegister,
                LastName = lastNameRegister,
                Age = ageRegister,
                Username = usernameRegister,
                Password = passwordRegister
            };
        }

        public int ChooseMenu<T>(List<T> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {items[i]}");
            }
            int choice = ValidationHelper.ValidateNumberInput(Console.ReadLine(), items.Count);
            return choice;
        }

        public void EndMenu()
        {
            throw new NotImplementedException();
        }

        public int GetUserInputAsInt(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            int number;
            while (!int.TryParse(input, out number))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
                input = Console.ReadLine();
            }

            return number;
        }

    }
}
