using ConsultorioSeguros.BLL;
using ConsultorioSeguros.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ConsultorioSeguros.API.Controllers
{
    [ApiController]
    [Route("api/asegurado_seguro")]
    public class AseguradoSeguroController : ControllerBase
    {
        private readonly IAseguradoSeguroService _aseguradoSeguroService;

        public AseguradoSeguroController(IAseguradoSeguroService aseguradoSeguroService)
        {
            _aseguradoSeguroService = aseguradoSeguroService;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignSeguroToAsegurado([FromBody] AseguradoSeguro request)
        {
            Response response = await _aseguradoSeguroService.AssignSeguroToAsegurado(request.AseguradoCedula, request.SeguroCodigo);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("seguros/{cedula}")]
        public async Task<IActionResult> GetSegurosByAseguradoCedula(string cedula)
        {
            List<Seguro> seguros = await _aseguradoSeguroService.GetSegurosByAseguradoCedula(cedula);
            return Ok(seguros);
        }

        [HttpGet("asegurados/{codigo}")]
        public async Task<IActionResult> GetAseguradosBySeguroCodigo(string codigo)
        {
            List<Asegurado> asegurados = await _aseguradoSeguroService.GetAseguradosBySeguroCodigo(codigo);
            return Ok(asegurados);
        }
    }
}

