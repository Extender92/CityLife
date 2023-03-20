using CityLifeProj.Models;
using System.Reflection;

namespace CityLifeProj.Views;

public partial class NewGamePage : ContentPage
{
    ViewModels.NewGameViewModel vm = new ViewModels.NewGameViewModel();

    public NewGamePage()
	{
		InitializeComponent();
        BindingContext = vm;
    }


    private async void OnClickedPlayGame(object sender, EventArgs e)
    {
        if (Player.GetInstance != null && InputName.Text.Count() > 3)
        {
            Player.GetInstance.SetName(InputName.Text);
            Player.GetInstance.SetImage(vm.PlayerImageSource);
            Application.Current.MainPage = new NavigationPage(new Views.CityPage());
        }
    }
}