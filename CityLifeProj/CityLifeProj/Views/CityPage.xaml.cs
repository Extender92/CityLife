using CityLifeProj.Models;

namespace CityLifeProj.Views;

public partial class CityPage : ContentPage
{
    ViewModels.CityViewModel vm = new ViewModels.CityViewModel();

    public CityPage()
	{
		InitializeComponent();
        BindingContext = vm;
        vm.ApiOpenWeather();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.UpdateViewPlayer();
        if (!vm.HasMasters)
        {
            vm.UpdatePlayerMasters();
            if (vm.HasMasters)
                OfficeButton.IsVisible = true;
        }
    }
    private async void OnClickedGoPlayerPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PlayerPage());
    }
    private async void OnClickedGoHomePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }
    private async void OnClickedGoUniversityPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UniversityPage());
    }
    private async void OnClickedGoGroceryStorePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GroceryStorePage());
    }
    private async void OnClickedGoElectronicsStorePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ElectronicsStorePage());
    }
    private async void OnClickedGoHardwareStorePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HardwareStorePage());
    }
    private async void OnClickedGoBurgerPrincePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BurgerPrincePage());
    }
    private async void OnClickedGoOfficePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OfficePage());
    }
}