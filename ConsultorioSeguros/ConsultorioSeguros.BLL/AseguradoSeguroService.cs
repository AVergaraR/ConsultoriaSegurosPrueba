using ConsultorioSeguros.DAL;
using ConsultorioSeguros.Entities;

namespace ConsultorioSeguros.BLL
{
    public class AseguradoSeguroService : IAseguradoSeguroService
    {
        private readonly IAseguradoSeguroRepository _aseguradoSeguroRepository;

        public AseguradoSeguroService(IAseguradoSeguroRepository aseguradoSeguroRepository)
        {
            _aseguradoSeguroRepository = aseguradoSeguroRepository;
        }

        public async Task<Response> AssignSeguroToAsegurado(string cedula, List<string> seguroCodigos)
        {
            try
            {
                
                string segurosConcatenados = string.Join(",", seguroCodigos);

                await _aseguradoSeguroRepository.AssignSeguroToAsegurado(cedula, segurosConcatenados);

                return new Response { Success = true, Message = "Seguros asignados exitosamente" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = "Error al asignar los seguros", Error = ex.Message };
            }
        }

        public async Task<List<Seguro>> GetSegurosByAseguradoCedula(string cedula)
        {
            return await _aseguradoSeguroRepository.GetSegurosByAseguradoCedula(cedula);
        }

        public async Task<List<Asegurado>> GetAseguradosBySeguroCodigo(string codigo)
        {
            return await _aseguradoSeguroRepository.GetAseguradosBySeguroCodigo(codigo);
        }
    }
}