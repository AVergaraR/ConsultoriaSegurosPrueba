using ConsultorioSeguros.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultorioSeguros.DAL
{
    public interface ISeguroRepository
    {
        Task<IEnumerable<Seguro>> GetAllSeguros();
        Task<Seguro> GetSeguroById(int id);
        Task<Seguro> GetSeguroByCodigo(string codigo);
        Task AddSeguro(Seguro seguro);
        Task UpdateSeguro(Seguro seguro);
        Task DeleteSeguro(int id);
        Task<IEnumerable<Seguro>> GetSegurosNoAsignadosPorAsegurado(string cedula);
    }
}