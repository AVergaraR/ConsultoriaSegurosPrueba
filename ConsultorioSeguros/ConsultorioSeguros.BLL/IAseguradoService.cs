using ConsultorioSeguros.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ConsultorioSeguros.BLL
{
    public interface IAseguradoService
    {
        Task<Response<IEnumerable<Asegurado>>> GetAllAsegurados();
        Task<Response<Asegurado>> GetAseguradoById(int id);
        Task<Response<Asegurado>> GetAseguradoByCedula(string cedula);
        Task<Response> AddAsegurado(Asegurado asegurado);
        Task<Response> UpdateAsegurado(Asegurado asegurado);
        Task<Response> DeleteAsegurado(int id);
        Task<Response<IEnumerable<Asegurado>>> GetAseguradosNoAsignadosPorSeguro(string codigoSeguro);
        Task<Response> BulkInsertAsegurados(string filePath);
    }
}