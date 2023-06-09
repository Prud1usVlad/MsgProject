using Msg.Mobile.Services.Interfaces;

namespace Msg.Mobile.Views;

public partial class Login : ContentPage
{
    private readonly IUserService _userService;

    public Login(IUserService userService)
    {
        InitializeComponent();
        _userService = userService;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (await _userService.Authenticate(UsernameEdit.Text, PasswordEdit.Text))
                App.Current.MainPage = Handler.MauiContext.Services.GetService<AppShell>();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Login failed", "Email or password is invalid", "Try again");
        }
    }
}