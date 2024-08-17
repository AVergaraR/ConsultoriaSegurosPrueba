using ConsultorioSeguros.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultorioSeguros.BLL
{
    public interface ISeguroService
    {
        Task<Response<IEnumerable<Seguro>>> GetAllSeguros();
        Task<Response<Seguro>> GetSeguroById(int id);
        Task<Response<Seguro>> GetSeguroByCodigo(string codigo);
        Task<Response> AddSeguro(Seguro seguro);
        Task<Response> UpdateSeguro(Seguro seguro);
        Task<Response> DeleteSeguro(int id);
        Task<Response<IEnumerable<Seguro>>> GetSegurosNoAsignadosPorAsegurado(string cedula);
    }
}