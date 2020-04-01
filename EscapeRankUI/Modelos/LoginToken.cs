
namespace EscapeRankUI.Modelos
{
    public class LoginToken
    {
        public string Status { get; set; }
        public string Id_token { get; set; }
        public string Access_token { get; set; }
        public int IdUsuario { get; set; }
        public string Data { get; set; }
        public string Token_type { get; set; }
        public string Refresh_token { get; set; }
        public string Code { get; set; }
        public string Expires_in { get; set; }
        public string Message { get; set; }
    }
}
