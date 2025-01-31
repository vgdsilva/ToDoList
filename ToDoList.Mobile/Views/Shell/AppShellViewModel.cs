using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Data.Context;
using ToDoList.Mobile.Utils.Classes;
using ToDoList.Mobile.Views.Base;
using ToDoList.Mobile.Views.ToDo;

namespace ToDoList.Mobile.Views.Shell;

public partial class AppShellViewModel : BaseViewModels
{

    public AppShellViewModel()
    {
        
    }

    public override void OnAppearing()
    {
        base.OnAppearing();
    }

    [RelayCommand]
    async Task AddToDoItem()
    {
        await NavigationUtils.GoToAsync(nameof(ToDoItemPage));
    }

}
