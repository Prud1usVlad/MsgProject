using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Msg.Mobile.Models;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Msg.Mobile.ViewModels
{
    [INotifyPropertyChanged]
    public partial class HelperMainViewModel
    {
        private readonly ISubstrateService _substrateService;
        private readonly IPlantService _plantService;

        [ObservableProperty]
        public bool isLoading;

        [ObservableProperty]
        private ObservableCollection<Plant> plants;

        [ObservableProperty]
        private ObservableCollection<Substrate> substrates;

        [ObservableProperty]
        private Plant selectedPlant;

        [ObservableProperty]
        private ObservableCollection<Substrate> selectedSubstrates;

        [ObservableProperty]
        private double x;

        [ObservableProperty]
        private double y;

        [ObservableProperty]
        private double z;

        [ObservableProperty]
        private double d;

        [ObservableProperty]
        private bool isPlantCardVisible;

        [ObservableProperty]
        private bool isSubstratesCardsVisible;

        public HelperMainViewModel(IPlantService plantService, ISubstrateService substrateService)
        {
            _plantService = plantService;
            _substrateService = substrateService;


            plants = new ObservableCollection<Plant>();
            substrates = new ObservableCollection<Substrate>();
            selectedSubstrates = new ObservableCollection<Substrate>();
            selectedPlant = null;

            x = 10;
            y = 5;
            z = 0.1;
            d = 0.1;
        }


        [RelayCommand]
        private async Task LoadData()
        {
            IsLoading = true;

            try
            {
                SelectedSubstrates.Clear();
                Plants = (await _plantService.GetPlants()).ToObservableCollection();
                Substrates = (await _substrateService.GetSubstrates()).ToObservableCollection();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't load data. See inner error: " + ex.Message, "OK");
            }

            IsLoading = false;
        }

        [RelayCommand]
        private async Task Optimize()
        {
            var data = new HelperInput
            {
                Deviation = D,
                SelectedPlantId = SelectedPlant.Id,
                SubstrateVolume = X * Y * Z,
                SelectedSubstratesId = SelectedSubstrates.Select(s => s.Id).ToList(),
            };

            var dataStr = JsonSerializer.Serialize(data);

            Preferences.Default.Set(nameof(HelperInput), dataStr);

            await Shell.Current.GoToAsync(nameof(Views.HelperResult));
        }

        [RelayCommand]
        private void SubstratesChanged()
            => IsSubstratesCardsVisible = Substrates.Count() > 0;

        [RelayCommand]
        private void PlantsChanged()
            => IsPlantCardVisible = SelectedPlant is not null;
    }
}
