

using System.Data;
using TimeTracking.Domain.Models;
using TimeTracking.Services.Enums;

namespace TimeTracking.Services.Interfaces
{
    public interface IUIService
    {
        List<MenuChoice> MenuItems { get; set; }
        User LoginMenu();
        User RegisterMenu();
        int ChooseMenu<T>(List<T> items);
        void EndMenu();
        int GetUserInputAsInt(string message);

    }
}
