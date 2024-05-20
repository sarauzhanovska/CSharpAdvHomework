

using System.Diagnostics;
using TimeTracking.Domain.Enums;
using TimeTracking.Helpers;

namespace TimeTracking.Domain.Models
{
    public class ReadingTracker 
    {
        public int Pages { get; set; }
        public TypeReading TypeReading { get; set; }

      public void TrackReading()
        {
          

            ExtendedConsole.PrintInColor("Please enter the type of reading:");
            string readingType = Console.ReadLine();
            Stopwatch stopwatch = Stopwatch.StartNew();
            ExtendedConsole.PrintInColor("Countdown for this activity is started....");
            ExtendedConsole.PrintInColor("Press Enter to stop tracking...");
            Console.ReadLine();
            stopwatch.Stop();
            ExtendedConsole.PrintInColor("Please enter the number of pages read:");
            int pagesRead = Convert.ToInt32(Console.ReadLine());
            TimeSpan timeSpent = stopwatch.Elapsed;
            ExtendedConsole.PrintSuccess($"Tracked {pagesRead} pages of {readingType} in {timeSpent.TotalMinutes} minutes.");
            ExtendedConsole.PrintInColor("Press Enter to return to the main menu...");
            Console.ReadLine();
        }

    }
}
