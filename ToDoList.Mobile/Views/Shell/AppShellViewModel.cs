using CommunityToolkit.Mvvm.Input;
using ToDoList.Mobile.Utils.Classes;
using ToDoList.Mobile.Views.Base;
using ToDoList.Mobile.Views.ToDo;

namespace ToDoList.Mobile.Views.Shell;

public partial class AppShellViewModel : BaseViewModels
{



    [RelayCommand]
    async Task AddToDoItem()
    {
        await NavigationUtils.GoToAsync(nameof(ToDoItemPage));
    }

}
