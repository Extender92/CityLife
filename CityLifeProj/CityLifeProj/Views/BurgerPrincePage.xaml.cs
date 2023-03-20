using CityLifeProj.Models;
using CityLifeProj.ViewModels;
using static CityLifeProj.Models.Perks;
using static CityLifeProj.Models.Job;

namespace CityLifeProj.Views;

public partial class BurgerPrincePage : ContentPage
{
    ViewModels.BurgerPrinceViewModel vm = new ViewModels.BurgerPrinceViewModel();

    public BurgerPrincePage()
	{
		InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedGoPlayerPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PlayerPage());
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
    private async void OnClickedBuy(object sender, EventArgs e)
    {
        await BurgerPrinceViewModel.BurgerFood();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedWork(object sender, EventArgs e)
    {
        await BurgerPrinceViewModel.BurgerWork();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedApplyForWork(object sender, EventArgs e)
    {
        BurgerPrinceViewModel.BurgerApply();
    }
    private async void OnClickedQuitJob(object sender, EventArgs e)
    {
        BurgerPrinceViewModel.BurgerQuit();
    }
}