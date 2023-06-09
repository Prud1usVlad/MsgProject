using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Core.Internal;
using Msg.Mobile.Models;
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
    public partial class DeviceDetailsViewModel
    {
        private readonly IDeviceService _deviceService;
        private readonly IPlantService _plantService;
        private readonly long deviceId;

        [ObservableProperty]
        private SystemDevice selectedDevice;

        [ObservableProperty]
        private ObservableCollection<Plant> plants;

        [ObservableProperty]
        private Plant selectedPlant;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private ObservableCollection<object> firstSeries;

        [ObservableProperty]
        private ObservableCollection<object> secondSeries;

        [ObservableProperty]
        private ObservableCollection<object> thirdSeries;

        public DeviceDetailsViewModel(IDeviceService deviceService, IPlantService plantService)
        {
            _deviceService = deviceService;
            _plantService = plantService;

            deviceId = Preferences.Default.Get("SelectedDeviceId", -1);
            plants = new ObservableCollection<Plant>();
            firstSeries = new ObservableCollection<object>();
            secondSeries = new ObservableCollection<object>();
            thirdSeries = new ObservableCollection<object>();
        }

        [RelayCommand]
        private async Task LoadData()
        {
            IsLoading = true;

            try
            {
                SelectedDevice = await _deviceService.GetDeviceInfo(deviceId);

                PopulateChartWithData();

                SelectedPlant = selectedDevice.Plant;

                var pl = await _plantService.GetPlants();
                Plants.Clear();

                pl.ForEach(Plants.Add);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't load data. See inner error: " + ex.Message, "OK");
            }

            IsLoading = false;
        }

        [RelayCommand]
        private async Task ChangePlant()
        {
            try
            {
                await _deviceService.ChangeDevicePlant(deviceId, SelectedPlant.Id);
                await LoadData();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't change device plant. See inner error: " + ex.Message, "OK");
            }
        }

        private void PopulateChartWithData()
        {
            FirstSeries.Clear();
            SecondSeries.Clear();
            ThirdSeries.Clear();

            SelectedDevice.DataPieces.ForEach(piece =>
            {
                if (piece.Name.StartsWith("A"))
                    FirstSeries.Add(new { Value = piece.Value, Count = firstSeries.Count() + 1});
                else if (piece.Name.StartsWith("E"))
                    SecondSeries.Add(new { Value = piece.Value, Count = secondSeries.Count() + 1});
                else if (piece.Name.StartsWith("M"))
                    ThirdSeries.Add(new { Value = piece.Value, Count = thirdSeries.Count() + 1});
            });
        }
    }
}
