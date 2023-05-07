using Msg.Mobile.ViewModels;

namespace Msg.Mobile.Views;

public partial class HelperMain : ContentPage
{
	public readonly HelperMainViewModel ViewModel;

    public HelperMain(HelperMainViewModel viewModel)
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