namespace CityLifeProj.Views;

public partial class HomePage : ContentPage
{
    ViewModels.HomeViewModel vm = new ViewModels.HomeViewModel();
    public HomePage()
	{
		InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.UpdateViewPlayer();
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
    private async void OnClickedGoPlayerPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PlayerPage());
    }
    private async void OnClickedSleep(object sender, EventArgs e)
    {
        await vm.HomeSleep();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedPrepareFood(object sender, EventArgs e)
    {
        await vm.HomePrepareFood();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedEat(object sender, EventArgs e)
    {
        await vm.HomeEat();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedDrink(object sender, EventArgs e)
    {
        await vm.HomeDrink();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedUpgradeHome(object sender, EventArgs e)
    {
        vm.HomeUpgradeHome();
    }
}