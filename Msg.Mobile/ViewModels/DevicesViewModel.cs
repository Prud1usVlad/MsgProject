using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Msg.Mobile.Models;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Msg.Mobile.ViewModels
{
    [INotifyPropertyChanged]
    public partial class DevicesViewModel
    {
        private readonly IDeviceService _deviceService;

        [ObservableProperty]
        private ObservableCollection<SystemDevice> devices;

        [ObservableProperty]
        private bool isLoading; 

        public DevicesViewModel(IDeviceService deviceService)
        {
            _deviceService = deviceService;

            Devices = new ObservableCollection<SystemDevice>();
        }

        [RelayCommand]
        private async Task LoadData()
        {
            IsLoading = true;

            try
            {
                var dev = await _deviceService.GetUserDevices();

                Devices.Clear();
                dev.ForEach(Devices.Add);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't load data. See inner error: " + ex.Message, "OK");
            }

            IsLoading = false;
        }

        [RelayCommand]
        private async Task ShowDetails(long deviceId)
        {
            Preferences.Default.Set("SelectedDeviceId", deviceId);
            await App.Current.MainPage.DisplayAlert("Id:" + deviceId, "Details", "OK");
        }

    }
}
