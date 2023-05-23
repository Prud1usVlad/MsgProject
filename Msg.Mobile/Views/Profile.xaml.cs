using Msg.Mobile.ViewModels;

namespace Msg.Mobile.Views;

public partial class Profile : ContentPage
{
	public ProfileViewModel ViewModel;

    public Profile(ProfileViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;

        BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ViewModel.LoadDataCommand.Execute(null);
    }
}