using ConsultorioSeguros.Entities;

namespace ConsultorioSeguros.DAL
{
    public interface IAseguradoSeguroRepository
    {
        Task AssignSeguroToAsegurado(string cedula, string segurosConcatenados);
        Task<List<Seguro>> GetSegurosByAseguradoCedula(string cedula);
        Task<List<Asegurado>> GetAseguradosBySeguroCodigo(string codigo);
    }
}