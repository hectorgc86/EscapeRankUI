using Xamarin.Forms;

namespace EscapeRankUI
{
    public static class Constants
    {
        //Conexiones

        public static string EscapeRankURL
        {
            get
            {     
                if (Device.RuntimePlatform == Device.Android)
                { 
                    return "http://10.0.2.2:5000/api{0}"; //Conexión Android
                }
                else if (Device.RuntimePlatform == Device.iOS)
                {  
                    return "http://localhost:5000/api{0}"; //Conexión iOS
                }
                return null;
            }
        }

        public static string ImagenesAnchasURL
        {
            get
            {       
                if (Device.RuntimePlatform == Device.Android)
                {
                    return "http://10.0.2.2/files/img/anchas/"; //Ruta imágenes anchas Android
                }
                else if (Device.RuntimePlatform == Device.iOS)
                {
                    return "http://localhost/files/img/anchas/"; //Ruta imágenes anchas iOS
                }
                return null;
            }
}

    public static string ImagenesEstrechasURL
        {
            get
            {                
                if (Device.RuntimePlatform == Device.Android)
                {
                    return "http://10.0.2.2/files/img/estrechas/"; //Ruta imágenes estrechas Android
                }
                else if (Device.RuntimePlatform == Device.iOS)
                {
                    return "http://localhost/files/img/estrechas/"; //Ruta imágenes estrechas iOS
                }
                return null;
                
            }
        }



        /*OAUTH*/
        public static string LoginURL = "/login";
        public static string TokenAuthorizeUrl = "v1/oauth/authorize";
        public static string TokenValidateUrl = "v1/oauth/token/validate";
        public static string SignUpUrl = "signup";
        public static string ClientId = "escapeMobile";                 //CAMBIAR USER
        public static string ClientSecret = "..Escapemobile..";           //CAMBIAR PASSWORD

        /*API*/
        public static string SalasURL = "/salas";
        public static string SalasDetalleURL = "/salas/";
        public static string SalasConjuntoURL = "/salas/conjunto/";
        public static string SalasPromocionadasURL = "/salas/promocionadas/";
        public static string ProvincesUrl = "provinces/get";
        public static string ThemesUrl = "themes/get";
        public static string CategoriesUrl = "categories/get";
        public static string AudiencesUrl = "audiences/get";

        /*PARTIDAS*/
        public static string PartidasURL = "/partidas";
        public static string PartidasDetalleURL = "/partidas/";
        public static string MatchesSaveUrl = "matches/save";
        public static string MatchesUpdateUrl = "matches/update";
        public static string MatchesDeleteUrl = "matches/delete";

        /*PERFILES*/
        public static string PerfilesURL = "/perfiles";
        public static string PerfilDetalleURL = "/perfil/";
        public static string ProfilesSaveUrl = "profiles/save";
        public static string ProfilesUpdateUrl = "profiles/update";
        public static string ProfilesDeleteUrl = "profiles/delete";

        //USUARIOS
        public static string UsuariosURL = "/usuarios";
        public static string UsuarioDetalleURL = "/usuarios/";
        public static string UsersSaveUrl = "users/save";
        public static string UsersUpdateUrl = "users/update";
        public static string UsersDeleteUrl = "users/delete";

        //EQUIPOS
        public static string EquiposURL = "/equipos";
        public static string EquiposDetalleURL = "/equipos/";
        public static string TeamsSaveUrl = "teams/save";
        public static string TeamsUpdateUrl = "teams/update";
        public static string TeamsDeleteUrl = "teams/delete";

        //AMIGOS
        public static string AmigosURL = "/amigos";
        public static string AmigosDetalleURL = "/amigos/";
        public static string FriendsSaveUrl = "friends/save";
        public static string FriendsUpdateUrl = "friends/update";
        public static string FriendsDeleteUrl = "friends/delete";

        /*WALL*/
        public static string NoticiasURL = "/noticias";
        public static string NoticiasDetalleURL = "/noticias/";
        public static string NewsSaveUrl = "news/save";
        public static string NewsUpdateUrl = "news/update";
        public static string NewsDeleteUrl = "news/delete";
        public static string NewsCommentUrl = "news/comment"; //TODO ADD IN INTERFACE
        public static string NewsMarkAsFavUrl = "news/markAsFav";  //TODO ADD IN INTERFACE

        public static string AppName = "EscapeApp";

        // OAuth
        // For Google login, configure at https://console.developers.google.com/
        public static string GoogleiOSClientId = "escapemobil";
        public static string GoogleAndroidClientId = "516419883323-e62nbs7tjr49u57dhd3t8tmbn2urueh5.apps.googleusercontent.com";


        // These values do not need changing
        public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
        public static string GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public static string GoogleTokenAccesoUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string GoogleUserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

        // Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
        public static string GoogleiOSRedirectUrl = "todorest.angelvb.com:/oauth2redirect";
        public static string GoogleAndroidRedirectUrl = "com.googleusercontent.apps.516419883323-e62nbs7tjr49u57dhd3t8tmbn2urueh5:/oauth2redirect";


    }
}
