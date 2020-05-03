using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface ILoginService
    {
        Task<Login> GetLoginAsync(string email, string contrasenya);

        Task<Login> PostRegistroAsync(string nombre, string email, string contrasenya);
    }
}