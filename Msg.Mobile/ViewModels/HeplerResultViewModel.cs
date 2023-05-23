using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Utils.StructuredStorage.Internal.Reader;
using Msg.Mobile.Models;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Msg.Mobile.ViewModels
{
    [INotifyPropertyChanged]
    public partial class HeplerResultViewModel
    {
        private readonly IHelperService _helperService;
        private readonly JsonSerializerOptions _serializerOptions; 

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private HelperResult helperResult;

        [ObservableProperty]
        private string header;

        [ObservableProperty]
        private string subheader;


        public HeplerResultViewModel(IHelperService helperService, JsonSerializerOptions serializerOptions)
        {
            _helperService = helperService;
            _serializerOptions = serializerOptions;
        }

        [RelayCommand]
        private async Task LoadData()
        {
            IsLoading = true;

            try
            {
                var inputStr = Preferences.Default.Get(nameof(HelperInput), "none");
                var input = JsonSerializer.Deserialize<HelperInput>(inputStr);

                var temp = await _helperService.UseOptimizingModel(input);
                var newResults = new List<SubstrateComponent>();

                foreach (var item in temp.Result) 
                    if (item.Volume > 0) newResults.Add(item);

                temp.Result = newResults;
                HelperResult = temp;

                if (HelperResult.IsSucceed) 
                {
                    Header = "Optimization succeeded!";
                    Subheader = "Below you can see your results";
                }
                else
                {
                    Header = "Optimization failed";
                    Subheader = "But we provided result with the lowest deviation possible using data you provided." +
                        " Check this out, or change your input, for example expand the list of substrates, or increase deviation";
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't load data. See inner error: " + ex.Message, "OK");
            }

            IsLoading = false;
        }

        public async Task ExposeLoadData()
        {
            await LoadData();
        }
    }
}
