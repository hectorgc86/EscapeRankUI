using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using EscapeRankUI.Modelos;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.ViewModels
{
    public class PartidaViewModel : BaseViewModel
    {
        private Equipo _equipoSeleccionado;
        private TimeSpan _horaPartida;
        private DateTime _fechaPartida;
        private bool _botonValidarActivado;
        private bool _botonGuardarActivado;
        public int NumeroEquipoSeleccionado { get; set; }

        private ObservableCollection<Equipo> _equiposUsuario;

        public PartidaViewModel()
        {
            ValidarCommand = new Command(ValidarPartida);
            GuardarCommand = new Command(GuardarPartida);
            HacerFotoCommand = new Command(HacerFoto);

            NumeroEquipoSeleccionado = 0;
            BotonGuardarActivado = false;
            FechaPartida = DateTime.Now;
            HoraPartida = DateTime.Now.TimeOfDay;
            MinutosPartida = 60;
            SegundosPartida = 30;
        }

        public Sala SalaEscaneada { get; set; }
        public byte[] FotoPartida { get; set; }
        public int MinutosPartida { get; set; }
        public int SegundosPartida { get; set; }
        
        public Command ValidarCommand { get; }
        public Command GuardarCommand { get; }
        public Command HacerFotoCommand { get; }

        public bool BotonValidarActivado
        {
            get { return _botonValidarActivado; }
            set { SetProperty(ref _botonValidarActivado, value); }
        }

        public bool BotonGuardarActivado
        {
            get { return _botonGuardarActivado; }
            set { SetProperty(ref _botonGuardarActivado, value); }
        }

        public TimeSpan HoraPartida
        {
            get { return _horaPartida; }
            set { SetProperty(ref _horaPartida, value); }
        }
        public DateTime FechaPartida
        {
            get { return _fechaPartida; }
            set { SetProperty(ref _fechaPartida, value); }
        }

        public Equipo EquipoSeleccionado
        {
            get { return _equipoSeleccionado; }
            set { SetProperty(ref _equipoSeleccionado, value); }
        }

        public ObservableCollection<Equipo> EquiposUsuario
        {
            get { return _equiposUsuario; }
            set { SetProperty(ref _equiposUsuario, value); }
        }

        public async void GetEquipos()
        {
            Cargando = true;

            try
            {
                List<Equipo> equiposCall = await App.PerfilService.GetEquiposAsync();
                EquiposUsuario = new ObservableCollection<Equipo>(equiposCall);

                if (EquiposUsuario.Count > 0)
                {
                    BotonValidarActivado = true;

                    EquipoSeleccionado = EquiposUsuario[NumeroEquipoSeleccionado];
                }
                else
                {
                    BotonValidarActivado = false;
                    await Application.Current.MainPage.DisplayAlert("¡No tan rapido!", "No puedes registrar partida si no perteneces a un equipo", "OK");
                }
            }
            catch(HttpUnauthorizedException)
            {
                ErrorCredenciales();
            }
            finally
            {
              Cargando = false;
            }
            
        }

        //Hacer foto de partida

        private async void HacerFoto()
        {
            await CrossMedia.Current.Initialize();

             MediaFile foto = await CrossMedia.Current.TakePhotoAsync
                (new StoreCameraMediaOptions() {
                    CompressionQuality=70,
                    PhotoSize = PhotoSize.Small,
                    CustomPhotoSize = 70
                    });

            if (foto != null)
            {
                FotoPartida = File.ReadAllBytes(foto.Path);
            }

        }

        //Escanear QR de sala

        private async void ValidarPartida()
        {
            ZXingScannerPage qr = new ZXingScannerPage();

            qr.OnScanResult += async (result) =>
            {
                qr.IsScanning = false;

                try
                {
                    SalaEscaneada = await App.SalasService.GetSalaAsync(result.Text);
                }
                catch (HttpNotFoundException)
                {
                    await Application.Current.MainPage.DisplayAlert("Error","Sala no registrada", "OK");
                }
                catch (HttpUnauthorizedException)
                {
                    ErrorCredenciales();
                }

                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.Navigation.PopAsync();

                    Application.Current.MainPage.DisplayAlert("Código escaneado",
                        "Sala: \""+ SalaEscaneada.Nombre + "\" ha autorizado correctamente esta partida.", "OK");

                    BotonGuardarActivado = true;
                });
            };

            await Application.Current.MainPage.Navigation.PushAsync(qr);
        }

        private async void GuardarPartida()
        {
            FechaPartida.Add(HoraPartida);

            Partida partida = new Partida
            {
                Fecha = FechaPartida,
                Minutos = MinutosPartida,
                Segundos = SegundosPartida,
                Sala = SalaEscaneada,
                Equipo = EquipoSeleccionado
            };

            if (FotoPartida != null) {
                partida.Foto = FotoPartida;
            }

            try
            {
                Cargando = true;

                if (await App.PartidaService.PostPartidaAsync(partida))
                {
                    await Application.Current.MainPage.DisplayAlert("¡Enhorabuena!", "Partida registrada correctamente", "OK");

                    App.UsuarioPrincipal = await App.PerfilService.GetUsuarioAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Se ha producido un error registrando partida", "OK");
                }
            }
            catch(HttpUnauthorizedException)
            {
                ErrorCredenciales();
            }
            finally
            {
                Cargando = false;
            }

            BotonGuardarActivado = false;
        }
    }
}