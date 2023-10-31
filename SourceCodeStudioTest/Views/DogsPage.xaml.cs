using SourceCodeStudioTest.ViewModels;

namespace SourceCodeStudioTest.Views;

public partial class DogsPage : ContentPage
{
    public DogsPageViewModel ViewModel { get; }

    public DogsPage(DogsPageViewModel viewModel)
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