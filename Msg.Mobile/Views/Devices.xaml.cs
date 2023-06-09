using Msg.Mobile.ViewModels;

namespace Msg.Mobile.Views;

public partial class Devices : ContentPage
{
	public DevicesViewModel ViewModel { get; set; }
    public Devices(DevicesViewModel viewModel)
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