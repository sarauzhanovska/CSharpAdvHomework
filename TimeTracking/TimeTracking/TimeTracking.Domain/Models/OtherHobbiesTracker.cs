


using System.Diagnostics;
using TimeTracking.Helpers;

namespace TimeTracking.Domain.Models
{
    public class OtherHobbiesTracker 
    {
        public string HobbyName { get; set; }
   
        public void TrackHobby()
        {
            ExtendedConsole.PrintInColor("Please enter the name of the hobby:");
            string hobbyName = Console.ReadLine();
            Stopwatch stopwatch = Stopwatch.StartNew();
            ExtendedConsole.PrintInColor("Countdown for this activity is started....");
            ExtendedConsole.PrintInColor("Press Enter to stop tracking...");
            Console.ReadLine();
            stopwatch.Stop();
            TimeSpan timeSpent = stopwatch.Elapsed;
            ExtendedConsole.PrintSuccess($"Spent time on {hobbyName} for {timeSpent.TotalMinutes} minutes.");
            ExtendedConsole.PrintInColor("Press Enter to return to the main menu...");
            Console.ReadLine();
        }

    }
}
