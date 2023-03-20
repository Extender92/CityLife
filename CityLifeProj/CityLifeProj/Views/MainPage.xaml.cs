namespace CityLifeProj;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    }

    private async void OnClickedStartNewGame(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.NewGamePage());

    }
}

