using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SourceCodeStudioTest.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeStudioTest.ViewModels
{
    public partial class DogsPageViewModel : ObservableObject
    {
        private readonly IDogService dogService;

        public DogsPageViewModel(IDogService dogService)
        {
            this.dogService = dogService;
        }

        public ObservableCollection<DogViewModel> Dogs { get; } = new();

        [ObservableProperty]
        bool isLoading;

        public async Task InitialiseAsync()
        {
            if (IsLoading || Dogs.Count > 0) return;

            await GetDogAsync();
        }

        [RelayCommand]
        private async Task AddDog()
        {
            await GetDogAsync();
        }

        private async Task GetDogAsync()
        {
            IsLoading = true;

            var response = await dogService.GetRandomDogAsync();

            if (response.IsSuccessStatusCode &&
               response.Status.Equals("success", StringComparison.InvariantCultureIgnoreCase))
            {
                Dogs.Add(new DogViewModel(response));
            }

            IsLoading = false;
        }
    }
}
