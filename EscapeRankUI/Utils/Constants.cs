﻿using Xamarin.Forms;

namespace EscapeRankUI
{
    public static class Constants
    {
        public static string AppName = "EscapeRank";

        //CONEXIONES

        public static string IP = "192.168.0.18"; //"localhost"; //"10.0.2.2";
        public static string EscapeRankURL = "http://" + IP + ":5000/api{0}";
        public static string ImagenesAnchasURL = "http://" + IP + "/archivos/img/anchas/";
        public static string ImagenesEstrechasURL = "http://" + IP + "/archivos/img/estrechas/";

        //LOGIN
        public static string LoginURL = "/login";
        public static string RegistroURL = "/registro";
        public static string TokenAuthorizeUrl = "v1/oauth/authorize";
        public static string TokenValidateUrl = "v1/oauth/token/validate";
        public static string SignUpUrl = "signup";
        public static string ClientId = "escapeMobile";                 //CAMBIAR USER
        public static string ClientSecret = "..Escapemobile..";           //CAMBIAR PASSWORD

        //SALAS
        public static string SalasURL = "/salas";
        public static string SalasDetalleURL = "/salas/";
        public static string SalasPromocionadasURL = "/salas/promocionadas/";
        public static string SalasConjuntoURL = "/salas/conjunto/";
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
        public static string MatchesSaveUrl = "matches/save";
        public static string MatchesUpdateUrl = "matches/update";
        public static string MatchesDeleteUrl = "matches/delete";

        //PERFILES
        public static string PerfilesURL = "/perfiles";
        public static string PerfilDetalleURL = "/perfil/";
        public static string ProfilesSaveUrl = "profiles/save";
        public static string ProfilesUpdateUrl = "profiles/update";
        public static string ProfilesDeleteUrl = "profiles/delete";

        //USUARIOS
        public static string UsuariosURL = "/usuarios";
        public static string UsuarioDetalleURL = "/usuarios/";
        public static string UsuariosEquipoURL = "/usuarios/equipo/";
        public static string UsersSaveUrl = "users/save";
        public static string UsersUpdateUrl = "users/update";
        public static string UsersDeleteUrl = "users/delete";

        //EQUIPOS
        public static string EquiposURL = "/equipos";
        public static string EquiposDetalleURL = "/equipos/";
        public static string EquiposUsuarioURL = "/equipos/usuario/";

        public static string TeamsSaveUrl = "teams/save";
        public static string TeamsUpdateUrl = "teams/update";
        public static string TeamsDeleteUrl = "teams/delete";

        //AMIGOS
        public static string AmigosURL = "/amigos";
        public static string AmigosDetalleURL = "/amigos/";
        public static string FriendsSaveUrl = "friends/save";
        public static string FriendsUpdateUrl = "friends/update";
        public static string FriendsDeleteUrl = "friends/delete";

    }
}
