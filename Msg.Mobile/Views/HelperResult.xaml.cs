using Msg.Mobile.ViewModels;

namespace Msg.Mobile.Views;

public partial class HelperResult : ContentPage
{
	public HeplerResultViewModel ViewModel;

    public HelperResult(HeplerResultViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;

        BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ViewModel.ExposeLoadData();
    }
}