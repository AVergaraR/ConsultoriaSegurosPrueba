using ConsultorioSeguros.DAL;
using ConsultorioSeguros.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultorioSeguros.BLL
{
    public class SeguroService : ISeguroService
    {
        private readonly ISeguroRepository _seguroRepository;

        public SeguroService(ISeguroRepository seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }

        public async Task<Response<IEnumerable<Seguro>>> GetAllSeguros()
        {
            try
            {
                IEnumerable<Seguro> seguros = await _seguroRepository.GetAllSeguros();
                return new Response<IEnumerable<Seguro>> { Success = true, Data = seguros };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Seguro>> { Success = false, Message = "Error al obtener los seguros", Error = ex.Message };
            }
        }

        public async Task<Response<Seguro>> GetSeguroById(int id)
        {
            try
            {
                Seguro seguro = await _seguroRepository.GetSeguroById(id);
                return new Response<Seguro> { Success = true, Data = seguro };
            }
            catch (Exception ex)
            {
                return new Response<Seguro> { Success = false, Message = "Error al obtener el seguro", Error = ex.Message };
            }
        }

        public async Task<Response<Seguro>> GetSeguroByCodigo(string codigo)
        {
            try
            {
                Seguro seguro = await _seguroRepository.GetSeguroByCodigo(codigo);
                return new Response<Seguro> { Success = true, Data = seguro };
            }
            catch (Exception ex)
            {
                return new Response<Seguro> { Success = false, Message = "Error al obtener el seguro", Error = ex.Message };
            }
        }

        public async Task<Response> AddSeguro(Seguro seguro)
        {
            try
            {
                await _seguroRepository.AddSeguro(seguro);
                return new Response { Success = true, Message = "Seguro agregado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = "Error al agregar el seguro", Error = ex.Message };
            }
        }

        public async Task<Response> UpdateSeguro(Seguro seguro)
        {
            try
            {
                await _seguroRepository.UpdateSeguro(seguro);
                return new Response { Success = true, Message = "Seguro actualizado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = "Error al actualizar el seguro", Error = ex.Message };
            }
        }

        public async Task<Response> DeleteSeguro(int id)
        {
            try
            {
                await _seguroRepository.DeleteSeguro(id);
                return new Response { Success = true, Message = "Seguro eliminado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = "Error al eliminar el seguro", Error = ex.Message };
            }
        }

        public async Task<Response<IEnumerable<Seguro>>> GetSegurosNoAsignadosPorAsegurado(string cedula)
        {
            try
            {
                IEnumerable<Seguro> seguros = await _seguroRepository.GetSegurosNoAsignadosPorAsegurado(cedula);
                return new Response<IEnumerable<Seguro>> { Success = true, Data = seguros };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Seguro>> { Success = false, Message = "Error al obtener los seguros no asignados", Error = ex.Message };
            }
        }

    }
}