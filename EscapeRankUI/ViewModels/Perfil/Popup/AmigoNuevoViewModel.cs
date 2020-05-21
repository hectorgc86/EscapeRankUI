using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EscapeRankUI.ViewModels
{
    public class AmigoNuevoViewModel : BaseViewModel
    {
        private string _emailSolicitud;

        public AmigoNuevoViewModel()
        {
            EnviarSolicitudCommand = new Command(EnviarSolicitud);
        }

        public Command EnviarSolicitudCommand { get; }

        public string EmailSolicitud
        {
            get { return _emailSolicitud; }
            set { SetProperty(ref _emailSolicitud, value); }
        }


        private async void EnviarSolicitud()
        {
            if (string.IsNullOrEmpty(EmailSolicitud))
            {
                await Application.Current.MainPage.DisplayAlert("El campo email no debe estar vacío", null, "Ok");
            }
            else
            {
                try
                {
                    bool correcto = await App.PerfilService.PostAmigoAsync(EmailSolicitud);

                    if (correcto)
                    {
                        await Application.Current.MainPage.DisplayAlert("Solicitud amistad mandada con éxito", null, "Ok");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("No se ha podido procesar petición amistad", null, "Ok");
                    }
                }
                catch (HttpUnauthorizedException)
                {
                    ErrorCredenciales();
                }
                catch (HttpNotFoundException)
                {
                    await Application.Current.MainPage.DisplayAlert("No exite un usuario con ese mail", null, "Ok");
                }
                finally
                {
                    Cargando = false;
                    await PopupNavigation.Instance.PopAsync();
                }
            }
        }
    }
}
