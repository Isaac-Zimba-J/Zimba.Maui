using TestApp.Views;

namespace TestApp;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    
    private async void OnFabTestClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FabTestView());
    }

    private async void OnCardTestClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CardTestView());
    }
}