

using System.Diagnostics;
using TimeTracking.Domain.Enums;
using TimeTracking.Helpers;

namespace TimeTracking.Domain.Models
{
    public class WorkingTracker
    {
        public WorkLocation Location { get; set; }
   
        public void TrackWorking()
        {
            ExtendedConsole.PrintInColor("Please enter the working location:");
            string workingLocation = Console.ReadLine();
            Stopwatch stopwatch = Stopwatch.StartNew();
            ExtendedConsole.PrintInColor("Countdown for this activity is started....");
            ExtendedConsole.PrintInColor("Press Enter to stop tracking...");
            Console.ReadLine();
            stopwatch.Stop();
            TimeSpan timeSpent = stopwatch.Elapsed;
            ExtendedConsole.PrintSuccess($"Worked {workingLocation} for {timeSpent.TotalMinutes} minutes.");
            ExtendedConsole.PrintInColor("Press Enter to return to the main menu...");
            Console.ReadLine();

           
        }
    }
}
