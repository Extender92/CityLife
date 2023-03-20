namespace CityLifeProj.Views;

public partial class OfficePage : ContentPage
{
    ViewModels.OfficeViewModel vm = new ViewModels.OfficeViewModel();
    public OfficePage()
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
    private async void OnClickedWork(object sender, EventArgs e)
    {
        await vm.OfficeWork();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedApplyForWork(object sender, EventArgs e)
    {
        vm.OfficeApply();
    }
    private async void OnClickedQuitJob(object sender, EventArgs e)
    {
        vm.OfficeQuit();
    }
}