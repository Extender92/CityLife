namespace CityLifeProj.Views;

public partial class HardwareStorePage : ContentPage
{
    ViewModels.HardwareStoreViewModel vm = new ViewModels.HardwareStoreViewModel();
    public HardwareStorePage()
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
    private async void OnClickedBuy(object sender, EventArgs e)
    {
        await vm.HardwareBuy();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedWork(object sender, EventArgs e)
    {
        await vm.HardwareWork();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedApplyForWork(object sender, EventArgs e)
    {
        vm.HardwareApply();
    }
    private async void OnClickedQuitJob(object sender, EventArgs e)
    {
        vm.HardwareQuit();
    }
}