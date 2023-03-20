using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CityLifeProj.ViewModels
{
    internal partial class NewGameViewModel : BaseViewModel
    {
        [ObservableProperty]
        string playerImageSource;

        public NewGameViewModel()
        {
            PlayerImageSource = "portraitfemaleblue.jpg";
        }

        [RelayCommand]
        public void SetPortrait(string portrait)
        {
            PlayerImageSource = portrait;
        }
    }
}
