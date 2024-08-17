using ConsultorioSeguros.BLL;
using ConsultorioSeguros.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioSeguros.API.Controllers
{
    [ApiController]
    [Route("api/seguro")]
    public class SeguroController : ControllerBase
    {
        private readonly ISeguroService _seguroService;

        public SeguroController(ISeguroService seguroService)
        {
            _seguroService = seguroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeguros()
        {
            Response response = await _seguroService.GetAllSeguros();
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(500, response);
        }

        // GET api/seguro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeguroById(int id)
        {
            Response<Seguro> response = await _seguroService.GetSeguroById(id);
            if (response.Success)
            {
                if (response.Data != null)
                {
                    return Ok(response);
                }
                return NotFound();
            }
            return StatusCode(500, response);
        }

        // GET api/seguro/codigo/{codigo}
        [HttpGet("codigo/{codigo}")]
        public async Task<IActionResult> GetSeguroByCodigo(string codigo)
        {
            Response response = await _seguroService.GetSeguroByCodigo(codigo);
            if (response.Success)
                return Ok(response);
            return StatusCode(500, response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeguro([FromBody] Seguro seguro)
        {
            if (ModelState.IsValid)
            {
                Response response = await _seguroService.AddSeguro(seguro);
                if (response.Success)
                {
                    return CreatedAtAction(nameof(GetSeguroById), new { id = seguro.Id }, seguro);
                }
                return StatusCode(500, response);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeguro([FromBody] Seguro seguro)
        {
            if (ModelState.IsValid)
            {
                Response response = await _seguroService.UpdateSeguro(seguro);
                if (response.Success)
                {
                    return NoContent();
                }
                return StatusCode(500, response);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguro(int id)
        {
            Response response = await _seguroService.DeleteSeguro(id);
            if (response.Success)
            {
                return NoContent();
            }
            return StatusCode(500, response);
        }

        [HttpGet("no_asignados/{cedula}")]
        public async Task<IActionResult> GetSegurosNoAsignadosPorAsegurado(string cedula)
        {
            Response response = await _seguroService.GetSegurosNoAsignadosPorAsegurado(cedula);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
