using CityLifeProj.ViewModels;

namespace CityLifeProj.Views;

public partial class ElectronicsStorePage : ContentPage
{
    ViewModels.ElectronicsStoreViewModel vm = new ViewModels.ElectronicsStoreViewModel();
    public ElectronicsStorePage()
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
        await vm.ElectronicBuy();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedWork(object sender, EventArgs e)
    {
        await vm.ElectronicWork();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedApplyForWork(object sender, EventArgs e)
    {
        vm.ElectronicApply();
    }
    private async void OnClickedQuitJob(object sender, EventArgs e)
    {
        vm.ElectronicQuit();
    }
}