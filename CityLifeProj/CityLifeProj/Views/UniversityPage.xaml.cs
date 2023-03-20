namespace CityLifeProj.Views;

public partial class UniversityPage : ContentPage
{
    ViewModels.UniversityViewModel vm = new ViewModels.UniversityViewModel();
    public UniversityPage()
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
    private async void OnClickedApplyToUnivercity(object sender, EventArgs e)
    {
        await vm.UniversityApply();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedStudy(object sender, EventArgs e)
    {
        await vm.UniversityStudy();
        vm.UpdateViewPlayer();
    }
    private async void OnClickedGetMasters(object sender, EventArgs e)
    {
        vm.UniversityMasters();
    }
}