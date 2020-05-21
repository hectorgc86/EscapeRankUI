using System;
namespace EscapeRankUI.Modelos
{
    public class Amigo : Usuario
    {
        public Estado Estado { get; set; }
    }

    public enum Estado
    {
        pendiente,
        aceptado,
        borrado
    }
}
