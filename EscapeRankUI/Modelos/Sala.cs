using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EscapeRankUI.Modelos
{
    public partial class Sala
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Mostrada { get; set; }
        public string Duracion { get; set; }
        public int? MinimoJugadores { get; set; }
        public int? MaximoJugadores { get; set; }
        public string PrecioMinimo { get; set; }
        public string Descripcion { get; set; }
        public string PrecioMaximo { get; set; }
        public string UrlReserva { get; set; }
        public string EdadPublico { get; set; }
        public string Proximamente { get; set; }
        public string Visto { get; set; }
        public string ModoCombate { get; set; }
        public string TextoCombate { get; set; }
        public string SalaIgual { get; set; }
        public string EnOferta { get; set; }
        public string TextoOferta { get; set; }
        public string NumeroResenyas { get; set; }
        public string RegaloBonus { get; set; }
        public string DisponibleIngles { get; set; }
        public string AdaptadoMinusvalidos { get; set; }
        public string AdaptadoCiegos { get; set; }
        public string AdaptadoSordos { get; set; }
        public string AdaptadoEmbarazadas { get; set; }
        public string NoClaustrofobicos { get; set; }
        public string ImagenAncha { get; set; }
        public string ImagenEstrecha { get; set; }
        public string JugadoresIncluidos { get; set; }
        public string PrecioJugadorAdicional { get; set; }
        public string Validez { get; set; }
        public string ComoReservar { get; set; }
        public string TerminosReserva { get; set; }
        public string OtrosDatos { get; set; }
        public string CompanyiaId { get; set; }
        public string DificultadId { get; set; }
        public bool EsVisible { get; set; }

        public Companyia Companyia { get; set; }
        public Dificultad Dificultad { get; set; }
        public Provincia Provincia { get; set; }
        public Ciudad Ciudad { get; set; }
        public List<Partida> Partidas { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<Tematica> Tematicas { get; set; }
        public List<Publico> Publico { get; set; }


        public ImageSource ImagenUriAncha
        {
            get
            {
                var url = Constantes.ImagenesAnchasURL + ImagenAncha;
                return ImageSource.FromUri(new Uri(url, UriKind.Absolute));
            }
            set { ImagenUriAncha = value; }
        }

        public ImageSource ImagenUriEstrecha
        {
            get
            {
                var url = Constantes.ImagenesEstrechasURL + ImagenEstrecha;
                return ImageSource.FromUri(new Uri(url, UriKind.Absolute));
            }
            set { ImagenUriEstrecha = value; }
        }
    }
}
