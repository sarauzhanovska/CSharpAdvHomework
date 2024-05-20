using System.Data;
using System.Diagnostics;
using TimeTracking.Domain.Enums;
using TimeTracking.Domain.Models;
using TimeTracking.Helpers;
using TimeTracking.Services;
using TimeTracking.Services.Enums;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.App
{
    internal class TimeTrackingUI
    {
        private readonly IUIService _uiService;
        private readonly IUserService _userService;
        private readonly ReadingTracker _readingTracker;
        private readonly ExercisingTracker _exercisingTracker;
        private readonly WorkingTracker _workingTracker;
        private readonly OtherHobbiesTracker _otherHobbiesTracker;

        public TimeTrackingUI()
        {
            _uiService = new UIService();
            _userService = new UserService();
            _readingTracker = new ReadingTracker();
            _exercisingTracker = new ExercisingTracker();
            _workingTracker = new WorkingTracker();
            _otherHobbiesTracker = new OtherHobbiesTracker();
            InitializeStartingData();
        }

        public void InitApp()
        {


            while (true)
            {
                Console.Clear();
                #region Login and Register
                if (_userService.CurrentUser == null)
                {
                    try
                    {
                        ExtendedConsole.PrintTitle("\n\t *** Time Tracking ***\n");
                        int choice = _uiService.ChooseMenu(new List<string> { "Login", "Register", "Exit" });
                        if (choice == -1)
                        {
                            ExtendedConsole.PrintError("Invalid choice. Try again!");
                            continue;
                        }
                        if (choice == 3)
                        {
                            Console.WriteLine("Goodbye!");
                            break;
                        }

                        if (choice == 1)
                        {

                            User inputUser = _uiService.LoginMenu();
                            if (_userService.Login(inputUser.Username, inputUser.Password))
                            {
                                ExtendedConsole.PrintSuccess($"\nWelcome {_userService.CurrentUser.FirstName} {_userService.CurrentUser.LastName}!!");

                            }
                            else
                            {
                                ExtendedConsole.PrintError("Login failed. Please try again.");

                            }
                        }

                        if (choice == 2)
                        {
                            User newUser = _uiService.RegisterMenu();
                            _userService.Register(newUser.FirstName, newUser.LastName, newUser.Age, newUser.Username, newUser.Password);
                            ExtendedConsole.PrintSuccess($"\nRegistration successful! Welcome, {newUser.Username}.");
                            continue;
                        }


                    }
                    catch (Exception ex)
                    {
                        ExtendedConsole.PrintError(ex.Message);
                        continue;
                    }

                    #endregion
                }
                else
                {
                    int loggedInChoice = _uiService.ChooseMenu(new List<string> { "Logout", "Track Activity", "User Statistics", "Account Management", "Exit" });
                    if (loggedInChoice == 1)
                    {
                        _userService.Logout();
                    }
                    if (loggedInChoice == 2)
                    {
                        TrackActivity();
                    }
                    if (loggedInChoice == 4)
                    {
                        AccountManagement();
                    }
                    if (loggedInChoice == 5)
                    {
                        ExtendedConsole.PrintInColor("Goodbye!");
                        break;
                    }
                }

            }

        }

        public void TrackActivity()
        {
            Console.Clear();
            ExtendedConsole.PrintTitle("\n\t *** Track Activity ***\n");
            List<string> activities = new List<string>
            {
              "Reading",
              "Exercising",
              "Working",
              "Other Hobbies",
            };
            int choice = _uiService.ChooseMenu(activities);

            switch (choice)
            {
                case 1:
                    TrackReadingActivity();
                    break;
                case 2:
                    TrackExercisingActivity();
                    break;
                case 3:
                    TrackWorkingActivity();
                    break;
                case 4:
                    TrackOtherHobbiesActivity();
                    break;

                default:
                    ExtendedConsole.PrintError("Invalid choice. Please try again.");
                    break;
            }
        }

        private void TrackReadingActivity()
        {
            Console.Clear();
            ExtendedConsole.PrintTitle("\n\t *** Track Reading Activity ***\n");

            List<string> readingOptions = new List<string>
    {
        "Belles Letters",
        "Fiction",
        "Professional Literature",
        "Go Back"
    };
            int choice = _uiService.ChooseMenu(readingOptions);
            if (choice == 4) return;
            _readingTracker.TrackReading();

        }


        private void TrackExercisingActivity()
        {
            Console.Clear();
            ExtendedConsole.PrintTitle("\n\t *** Track Exercising Activity ***\n");

            List<string> exercisingOptions = new List<string>
    {
        "General",
        "Running",
        "Sport",
        "Go Back"
    };

            int choice = _uiService.ChooseMenu(exercisingOptions);
            if (choice == 4) return;
            _exercisingTracker.TrackExercising();

        }
        private void TrackWorkingActivity()
        {
            Console.Clear();
            ExtendedConsole.PrintTitle("\n\t *** Track Working Activity ***\n");

            List<string> workingOptions = new List<string>
    {
        "At the office",
        "From home",
        "Go Back"
    };

            int choice = _uiService.ChooseMenu(workingOptions);
            if (choice == 3) return;
            _workingTracker.TrackWorking();

        }
        private void TrackOtherHobbiesActivity()
        {
            Console.Clear();
            ExtendedConsole.PrintTitle("\n\t *** Track Other Hobbies Activity ***\n");

            List<string> otherHobbiesOptions = new List<string>
    {
        "Hobby 1",
        "Hobby 2",
        "Hobby 3",
        "Go Back"
    };

            int choice = _uiService.ChooseMenu(otherHobbiesOptions);
            if (choice == 4) return;
            _otherHobbiesTracker.TrackHobby();

        }

        private void AccountManagement()
        {
            Console.Clear();
            ExtendedConsole.PrintTitle("Account Management");
            int choice = _uiService.ChooseMenu(new List<string> { "Change Password", "Change First Name", "Change Last Name", "Go Back" });
            switch (choice)
            {
                case 1:
                    string oldPassword = ExtendedConsole.GetInput("Enter current password: ");
                    string newPassword = ExtendedConsole.GetInput("Enter new password: ");
                    _userService.ChangePassword(oldPassword, newPassword);
                    ExtendedConsole.PrintSuccess("Password changed successfully!");
                    break;
                case 2:
                    string oldFirstName = ExtendedConsole.GetInput("Enter current first name: ");
                    string newFirstName = ExtendedConsole.GetInput("Enter new first name: ");
                    _userService.ChangeFirstName(oldFirstName, newFirstName);
                    ExtendedConsole.PrintSuccess("First name changed successfully!");
                    break;
                case 3:
                    string oldLastName = ExtendedConsole.GetInput("Enter current last name: ");
                    string newLastName = ExtendedConsole.GetInput("Enter new last name: ");
                    _userService.ChangeLastName(oldLastName, newLastName);
                    ExtendedConsole.PrintSuccess("Last name changed successfully!");
                    break;
                case 4:
                    return;
                default:
                    ExtendedConsole.PrintError("Invalid choice. Please try again.");
                    break;
            }
        }

        private void InitializeStartingData()
        {
            if (_userService.GetAll().Count < 1)
            {
                User firstUser = new User("Bob", "Bobsky", 30, "bobsky123", "Bobsky123");
                User secondUser = new User("Jill", "Jillsky", 28, "jill123", "Jillsky123");
                User thirdUser = new User("Mike", "Mikesky", 25, "mike123", "Mikesky123");
                List<User> seedUsers = new List<User>() { firstUser, secondUser, thirdUser };
                _userService.Seed(seedUsers);

            }
        }
       

    }
}
