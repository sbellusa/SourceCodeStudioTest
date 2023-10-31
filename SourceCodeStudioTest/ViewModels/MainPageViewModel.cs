using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SourceCodeStudioTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeStudioTest.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ILocationService locationService;               

        public MainPageViewModel(ILocationService locationService)
        {
            this.locationService = locationService;

            // Bury St Edmunds
            ComparedLocation = new Location(52.2469, 0.7113);
        }

        [ObservableProperty]
        bool isLoading;

        [ObservableProperty]
        bool hasLocation;

        [ObservableProperty]
        Location location;

        [ObservableProperty]
        Location comparedLocation;

        public async Task InitialiseAsync()
        {
            if (IsLoading) return;

            IsLoading = true;
            Location = await locationService.GetLocationAsync();
            if (Location != null) HasLocation = true;
            IsLoading = false;
        }

        [RelayCommand]
        private async Task RefreshLocation()
        {
            if (IsLoading) return;

            IsLoading = true;
            var updatedLocation = await locationService.GetLocationAsync(true);
            if (updatedLocation != null) Location = updatedLocation;
            IsLoading = false;
        }        
        
        [RelayCommand]
        private async Task OpenMapLocation()
        {
            if (Location == null) return;

            await Location.OpenMapsAsync();
        }
    }
}
