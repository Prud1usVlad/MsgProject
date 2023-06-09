using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Msg.Mobile.Services.Interfaces;
using Msg.Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Msg.Mobile.ViewModels
{
    [INotifyPropertyChanged]
    public partial class ProfileViewModel
    {
        private readonly IUserService _userService;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string userId;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string phone;


        public ProfileViewModel(IUserService userService)
        {
            _userService = userService;

            UserId = Preferences.Default.Get("UserId", "None");

        }

        [RelayCommand]
        private async Task LoadData()
        {
            IsLoading = true;

            try
            {
                if (UserId == "None")
                    throw new ArgumentException("Can't find current user id");

                var user = await _userService.GetUser(UserId);

                Username = user.Username;
                Email = user.Email;
                Phone = user.Phone;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't load data. See inner error: " + ex.Message, "OK");
            }

            IsLoading = false;
        }

        [RelayCommand]
        private async Task UpdateData()
        {
            IsLoading = true;

            try
            {
                if (!IsEmailValid(Email))
                    throw new ArgumentException("New email is not valid");
                else if (!IsPhoneValid(Phone))
                    throw new ArgumentException("New phone number is not valid");

                await _userService.ChangeUserData(new
                {
                    id = UserId,
                    email = Email,
                    phone = Phone,
                    username = Username, 
                    roles = new string[0],
                });

                await App.Current.MainPage.DisplayAlert("Success", "Your profile data updated sucessfully", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't load data. See inner error: " + ex.Message, "OK");
            }

            IsLoading = false;
        }

        [RelayCommand]
        private async Task ChangePassword()
        {
            await Shell.Current.GoToAsync("changePassword");
        }

        [RelayCommand]
        private async Task LogOut()
        {
            await _userService.Forget();
            App.Current.MainPage = App.Current.MainPage.Handler.MauiContext.Services.GetService<Login>();
        }

        private bool IsEmailValid(string email) => 
            new EmailAddressAttribute().IsValid(email);

        private bool IsPhoneValid(string phone) =>
            Regex.IsMatch(phone, @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");
    }
}
