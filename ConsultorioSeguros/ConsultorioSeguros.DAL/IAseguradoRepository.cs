using ConsultorioSeguros.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ConsultorioSeguros.DAL { 
    public interface IAseguradoRepository
    {
        Task<IEnumerable<Asegurado>> GetAllAsegurados();
        Task<Asegurado> GetAseguradoById(int id);
        Task<Asegurado> GetAseguradoByCedula(string cedula);
        Task AddAsegurado(Asegurado asegurado);
        Task UpdateAsegurado(Asegurado asegurado);
        Task DeleteAsegurado(int id);
        Task<IEnumerable<Asegurado>> GetAseguradosNoAsignadosPorSeguro(string codigoSeguro);
        Task BulkInsertAsegurados(DataTable filePath);
    }
}