using Msg.Mobile.ViewModels;

namespace Msg.Mobile.Views;

public partial class DeviceDetails : ContentPage
{
	public DeviceDetailsViewModel ViewModel { get; set; }

    public DeviceDetails(DeviceDetailsViewModel viewModel)
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