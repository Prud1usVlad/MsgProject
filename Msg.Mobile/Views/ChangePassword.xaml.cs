using Msg.Mobile.ViewModels;

namespace Msg.Mobile.Views;

public partial class ChangePassword : ContentPage
{

	public ChangePasswordViewModel ViewModel;
    public ChangePassword(ChangePasswordViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;

        BindingContext = ViewModel;
    }
}