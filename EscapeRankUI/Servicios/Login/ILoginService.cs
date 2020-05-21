using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface ILoginService
    {
        Task<Login> GetLoginAsync(string usuario, string contrasenya);

        Task<Login> PostRegistroAsync(Usuario usuario);
    }
}