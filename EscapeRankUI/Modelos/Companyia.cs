﻿
/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Modelos
{
    public class Companyia
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Web { get; set; }
        public string TripAdvisor { get; set; }
        public string Facebook { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string NumeroLocal { get; set; }
        public string GoogleMaps { get; set; }
        public string NumeroOpiniones { get; set; }
        public string CodigoPostal { get; set; }
        public string Instagram { get; set; }
        public string Puntuacion { get; set; }
        public string Rango { get; set; }
        public string CiudadId { get; set; }

        public Ciudad Ciudad { get; set; }
    }
}
