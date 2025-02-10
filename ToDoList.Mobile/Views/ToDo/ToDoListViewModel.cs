using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using ToDoList.Domain.Entities;
using ToDoList.Mobile.Views.Base;

namespace ToDoList.Mobile.Views.ToDo;

public partial class ToDoListViewModel : BaseViewModels
{

    [ObservableProperty]
    ObservableCollection<ToDoItem> toDoItems;


    public ToDoListViewModel()
    {
        ToDoItems = new();
    }


}
