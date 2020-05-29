using System;

/* Héctor Granja Cortés
 * 2ºDAM Semipresencial
 * Proyecto fin de ciclo
   EscapeRank */

namespace EscapeRankUI
{
    //Excepciones custom para controlar las respuestas de la API

    public class HttpUnauthorizedException : Exception { }
    public class HttpConflictException : Exception { }
    public class HttpNotFoundException : Exception { }
    public class HttpBadRequestException : Exception { }

}
