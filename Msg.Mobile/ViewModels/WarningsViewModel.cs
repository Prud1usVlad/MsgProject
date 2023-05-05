using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Msg.Mobile.Models;
using Msg.Mobile.Services.Enums;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.ViewModels
{
    [INotifyPropertyChanged]
    public partial class WarningsViewModel
    {
        private readonly IWarningService _warningService;
        private readonly string noWarningsMessage = "No warnings found";

        [ObservableProperty]
        private ObservableCollection<Warning> warnings;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string subheader;

        [ObservableProperty]
        private string icon;

        [ObservableProperty]
        private string iconColor;

        public WarningsViewModel(IWarningService warningService)
        {
            _warningService = warningService;

            Warnings = new ObservableCollection<Warning>();
            Subheader = noWarningsMessage;
            Icon = IconNames.Success;
            IconColor = "Green";
        }

        [RelayCommand]
        private async Task LoadData()
        {
            IsLoading = true;

            try
            {
                var war = await _warningService.GetWarningsAsync();

                Warnings.Clear();

                war.ForEach(Warnings.Add);

                ChangeIndicators();
                
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't load data. See inner error: " + ex.Message, "OK");
            }


            IsLoading = false;
        }

        [RelayCommand]
        private async Task Resolve(long id)
        {
            try
            {
                await _warningService.ResolveWarningAsync(id);
                App.Current.MainPage.DisplayAlert("Success", "Warning successfully marked as resolved", "OK");

                await LoadData();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "An error occured while trying to perform this operation. See inner error: " + ex.Message, "OK");
            }
        }

        private void ChangeIndicators()
        {
            if (warnings.Count > 0)
            {
                Subheader = $"You have: {warnings.Count()} warnings";
                Icon = IconNames.Alert;
                IconColor = "Yellow";
            }
            else
            {
                Subheader = noWarningsMessage;
                Icon = IconNames.Success;
                IconColor = "Green";
            }

            
        }
    }
}
