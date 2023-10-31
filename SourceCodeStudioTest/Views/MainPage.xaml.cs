using SourceCodeStudioTest.ViewModels;

namespace SourceCodeStudioTest.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; }

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            this.BindingContext = ViewModel = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.InitialiseAsync();
        }
    }
}