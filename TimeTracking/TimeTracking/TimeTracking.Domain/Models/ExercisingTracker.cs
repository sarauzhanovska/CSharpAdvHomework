
using System.Diagnostics;
using TimeTracking.Domain.Enums;
using TimeTracking.Helpers;

namespace TimeTracking.Domain.Models
{
    public class ExercisingTracker 
    {
        public TypeExercising TypeExercising { get; set; }

        public void TrackExercising()
        {
            ExtendedConsole.PrintInColor("Please enter the type of exercising:");
            string exercisingType = Console.ReadLine();
            Stopwatch stopwatch = Stopwatch.StartNew();
            ExtendedConsole.PrintInColor("Countdown for this activity is started....");
            ExtendedConsole.PrintInColor("Press Enter to stop tracking...");
            Console.ReadLine();
            stopwatch.Stop();
            TimeSpan timeSpent = stopwatch.Elapsed;
            ExtendedConsole.PrintSuccess($"Tracked {exercisingType} for {timeSpent.TotalMinutes} minutes.");
            ExtendedConsole.PrintInColor("Press Enter to return to the main menu...");
            Console.ReadLine();
        }

    }
}
