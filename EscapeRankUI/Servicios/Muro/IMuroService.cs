using System.Collections.Generic;
using System.Threading.Tasks;
using EscapeRankUI.Modelos;

namespace EscapeRankUI.Servicios
{
    public interface IMuroService
    {
        Task<List<Noticia>> GetNoticiasAsync();
    }
}