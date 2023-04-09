
/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

using Xamarin.Forms;

namespace EscapeRankUI
{
    public static class Constantes
    {
        public static string AppName = "EscapeRank";

        //Rutas de llamada a la API

        //CONEXIONES

        //Conexión Azure

        /*private static readonly string IP = "https://apiescaperank.azurewebsites.net";
        private static readonly string StorageURL = "https://escaperankstorage.blob.core.windows.net";*/

        //Conexión Oracle VM

        private static readonly string IP = "http://132.145.65.153/escaperankapi";
        private static readonly string StorageURL = "http://132.145.65.153/escaperankstorage";
        public static string EscapeRankURL = IP + "/api";
        public static string ImagenesSalaAnchasURL = StorageURL + "/img/salas/anchas/";
        public static string ImagenesSalaEstrechasURL = StorageURL + "/img/salas/estrechas/";
        public static string ImagenesPartidasURL = StorageURL + "/img/partidas/";
        public static string ImagenesCompanyiasURL = StorageURL + "/img/companyias/";
        public static string ImagenDefaultURL = StorageURL + "/img/default.png";

        //LOGIN
        public static string LoginURL = "/login";
        public static string RegistroURL = "/registro";
        public static string ValidarTokenURL = "/validartoken";

        //SALAS
        public static string SalasURL = "/salas";
        public static string SalasDetalleURL = "/salas/";
        public static string SalasPromocionadasURL = "/salas/promocionadas/";
        public static string SalasCategoriaURL = "/salas/categoria/";
        public static string SalasTematicaURL = "/salas/tematica/";
        public static string SalasPublicoURL = "/salas/publico/";
        public static string SalasDificultadURL = "/salas/dificultad/";
        public static string SalasProvinciaURL = "/salas/provincia/";

        //NOTICIAS
        public static string NoticiasURL = "/noticias";
        public static string NoticiasDetalleURL = "/noticias/";
        public static string NoticiasUsuarioURL = "/noticias/usuario/";

        //CATEGORIAS
        public static string CategoriasURL = "/categorias";

        //TEMATICAS
        public static string TematicasURL = "/tematicas";

        //PUBLICO
        public static string PublicoURL = "/publico";

        //DIFICULTADES
        public static string DificultadesURL = "/dificultades";

        //PROVINCIAS
        public static string ProvinciasURL = "/provincias";

        //PARTIDAS
        public static string PartidasURL = "/partidas";
        public static string PartidasDetalleURL = "/partidas/";
        public static string PartidasEquipoURL = "/partidas/equipo/";
        public static string PartidasUsuarioURL = "/partidas/usuario/";
        public static string PartidasSalaURL = "/partidas/sala/";

        //PERFILES
        public static string PerfilesURL = "/perfiles";
        public static string PerfilDetalleURL = "/perfil/";

        //USUARIOS
        public static string UsuariosURL = "/usuarios";
        public static string UsuarioDetalleURL = "/usuarios/";
        public static string UsuariosEquipoURL = "/usuarios/equipo/";

        //EQUIPOS
        public static string EquiposURL = "/equipos";
        public static string EquiposDetalleURL = "/equipos/";
        public static string EquiposUsuarioURL = "/equipos/usuario/";

        //AMIGOS
        public static string AmigosURL = "/amigos";
        public static string AmigosDetalleURL = "/amigos/";

        //OTROS
        public static string OffsetQuery = "?offset=";
        public static string BusquedaQuery = "&busqueda=";
        public static string RutaFotosRandom = "https://picsum.photos/200/300?random=";

    }
}
