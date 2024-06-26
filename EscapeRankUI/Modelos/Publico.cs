﻿using Newtonsoft.Json;
using Xamarin.Forms;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI.Modelos
{
    public class Publico
    {
        public string Id { get; set; }
        public string Tipo { get; set; }
        public int NumeroSalas { get; set; }

        [JsonIgnore]
        public FontImageSource Icono
        {
            get
            {
                return (FontImageSource)Utils.GetResourceValue("icono_pub_" + Tipo.ToLower());
            }
            set { Icono = value; }
        }
    }
}
