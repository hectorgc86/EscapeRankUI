using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EscapeRankUI.Modelos;
using Plugin.Media;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace EscapeRankUI.ViewModels
{
    public class PartidaViewModel : BaseViewModel
    {
        private Equipo _equipoSeleccionado;
        private Sala _salaEscaneada;
        private bool _botonValidarActivado;
        private bool _botonGuardarActivado;

        private ObservableCollection<Equipo> _equiposUsuario;

        public PartidaViewModel()
        {
            ValidarCommand = new Command(ValidarPartida);
            GuardarCommand = new Command(GuardarPartida);
            HacerFotoCommand = new Command(HacerFoto);

            BotonGuardarActivado = false;
            FechaPartida = DateTime.Now;

            GetEquipos();
        }

        public DateTime HoraPartida { get; set; }
        public DateTime FechaPartida { get; set; }
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

        //Funciones

        private async void GetEquipos()
        {
            List<Equipo> equiposCall = await App.PerfilManager.GetEquiposAsync();
            EquiposUsuario = new ObservableCollection<Equipo>(equiposCall);

            if (EquiposUsuario.Count > 0)
            {
                BotonValidarActivado = true;
                EquipoSeleccionado = EquiposUsuario[0];
            }
            else
            {
                BotonValidarActivado = false;
                await Application.Current.MainPage.DisplayAlert("¡No tan rapido!", "No puedes registrar partida si no perteneces a un equipo", "OK");
            }
        }

        private async void HacerFoto(object obj)
        {
            Image image = new Image();

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

            await Application.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            
        }

        //Escanear QR de sala

        private async void ValidarPartida()
        {
            ZXingScannerPage qr = new ZXingScannerPage();

            qr.OnScanResult += async (result) =>
            {
                qr.IsScanning = false;

                _salaEscaneada = await App.SalasManager.GetSalaAsync(result.Text);
                
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.Navigation.PopAsync();

                    Application.Current.MainPage.DisplayAlert("Código escaneado", "Sala: \""+ _salaEscaneada.Nombre + "\" ha autorizado correctamente esta partida.", "OK");

                    BotonGuardarActivado = true;
                });
            };

            await Application.Current.MainPage.Navigation.PushAsync(qr);
        }

        //Guardar partida en BBDD
        private void GuardarPartida()
        {
            Partida partida = new Partida();

            App.PartidaManager.PostPartidaAsync(partida);
        }
    }
}