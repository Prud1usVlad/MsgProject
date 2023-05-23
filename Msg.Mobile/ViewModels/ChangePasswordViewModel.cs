using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.ViewModels
{
    [INotifyPropertyChanged]
    public partial class ChangePasswordViewModel
    {
        private readonly IUserService _userService;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string newPassword;

        [ObservableProperty]
        private string confirmPassword;

        public ChangePasswordViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        private async Task ChangePassword()
        {
            try
            {
                EnsureNewPassValid();

                var userId = Preferences.Default.Get("UserId", "none");
                await _userService.ChangePassword(userId, Password, NewPassword);

                await App.Current.MainPage.DisplayAlert("Success", "Password successfully changed", "OK");
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't change current password. See inner error: " + ex.Message, "OK");
            }
        }

        private void EnsureNewPassValid()
        {
            if (NewPassword != ConfirmPassword)
                throw new ArgumentException("New password is not confimed");
            else if (!NewPassword.Any(char.IsDigit))
                throw new ArgumentException("New password should contain numeric characters");
        }
    }
}
