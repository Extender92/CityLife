namespace CityLifeProj.Views;

public partial class PlayerPage : ContentPage
{
    ViewModels.PlayerViewModel vm = new ViewModels.PlayerViewModel();
    public PlayerPage()
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.UpdateViewPlayer();
        vm.UpdateDetailViewPlayer();
    }
}