using ConsultorioSeguros.Entities;
using System.Threading.Tasks;
namespace ConsultorioSeguros.BLL
{
    public interface IAseguradoSeguroService
    {
        Task<Response> AssignSeguroToAsegurado(string cedula, List<string> seguroCodigos);
        Task<List<Seguro>> GetSegurosByAseguradoCedula(string cedula);
        Task<List<Asegurado>> GetAseguradosBySeguroCodigo(string codigo);
    }
}