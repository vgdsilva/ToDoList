using ToDoList.Mobile.Views.Base;

namespace ToDoList.Mobile.Views.ToDo;

public partial class ToDoItemPage : ContentPage
{
	public ToDoItemPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as BaseViewModels)?.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        (BindingContext as BaseViewModels)?.OnDisappearing();

        base.OnDisappearing();
    }
}