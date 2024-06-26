﻿using EscapeRankUI.Views;
using Xamarin.Forms;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.ViewModels
{
    public class ResetPassViewModel : BaseViewModel
    {
        public Command ResetPassCommand { get; }
        public Command RegistrarCommand { get; }

        public ResetPassViewModel()
        {
            ResetPassCommand = new Command(ReestablecerPass);
            RegistrarCommand = new Command(Registrar);
        }

        private async void ReestablecerPass()
        {
            await Application.Current.MainPage.DisplayAlert("Esta función estará disponible en versiones futuras", null, "Ok");
        }

        private async void Registrar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroPage());
        }
    }
}




