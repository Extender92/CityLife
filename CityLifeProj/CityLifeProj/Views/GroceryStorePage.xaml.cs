namespace CityLifeProj.Views;

public partial class GroceryStorePage : ContentPage
{
    ViewModels.GroceryStoreViewModel vm = new ViewModels.GroceryStoreViewModel();
    public GroceryStorePage()
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
    private async void OnClickedBuyFood(object sender, EventArgs e)
    {
        await vm.GroceryBuyFood();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedBuyEnergyDrink(object sender, EventArgs e)
    {
        await vm.GroceryBuyEnergyDrink();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedBuyVegitables(object sender, EventArgs e)
    {
        await vm.GroceryBuyVegitables();
        vm.UpdateViewPlayer();
    }
}