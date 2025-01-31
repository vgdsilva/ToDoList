using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Mobile.Utils.Classes;

public static class NavigationUtils
{
    public static async Task GoToAsync(ShellNavigationState state)
    {
        await Shell.Current.GoToAsync(state);
    }
}
