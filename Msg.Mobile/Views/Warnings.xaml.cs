using Msg.Mobile.ViewModels;

namespace Msg.Mobile.Views;

public partial class Warnings : ContentPage
{
	public WarningsViewModel ViewModel { get; set; }

    public Warnings(WarningsViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ViewModel.LoadDataCommand.Execute(null);
    }
}