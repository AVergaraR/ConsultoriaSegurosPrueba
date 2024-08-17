using Microsoft.AspNetCore.Mvc;
using ConsultorioSeguros.BLL;
using ConsultorioSeguros.Entities;

namespace ConsultorioSeguros.API.Controllers
{

    [ApiController]
    [Route("api/asegurado")]
    public class AseguradoController : ControllerBase
    {
        private readonly IAseguradoService _aseguradoService;
        private readonly FileValidatorService _fileValidatorService;

        public AseguradoController(IAseguradoService aseguradoService, FileValidatorService fileValidatorService)
        {
            _aseguradoService = aseguradoService;
            _fileValidatorService = fileValidatorService;
        }

        // GET: api/asegurado
        [HttpGet]
        public async Task<IActionResult> GetAllAsegurados()
        {
            Response response = await _aseguradoService.GetAllAsegurados();
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(500, response);
        }

        // GET: api/asegurado/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAseguradoById(int id)
        {
            Response response = await _aseguradoService.GetAseguradoById(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // GET: api/asegurado/cedula/{cedula}
        [HttpGet("cedula/{cedula}")]
        public async Task<IActionResult> GetAseguradoByCedula(string cedula)
        {
            Response response = await _aseguradoService.GetAseguradoByCedula(cedula);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // POST: api/asegurado
        [HttpPost]
        public async Task<IActionResult> AddAsegurado([FromBody] Asegurado asegurado)
        {
            Response response = await _aseguradoService.AddAsegurado(asegurado);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetAseguradoById), new { id = asegurado.Id }, response);
            }
            return BadRequest(response);
        }

        // PUT: api/asegurado
        [HttpPut]
        public async Task<IActionResult> UpdateAsegurado([FromBody] Asegurado asegurado)
        {
            Response response = await _aseguradoService.UpdateAsegurado(asegurado);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        // DELETE: api/asegurado/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsegurado(int id)
        {
            Response response = await _aseguradoService.DeleteAsegurado(id);
            if (response.Success)
            {
                return NoContent();
            }
            return NotFound(response);
        }

        // GET: api/asegurado/no_asignados/{codigoSeguro}
        [HttpGet("no_asignados/{codigoSeguro}")]
        public async Task<IActionResult> GetAseguradosNoAsignadosPorSeguro(string codigoSeguro)
        {
            Response response = await _aseguradoService.GetAseguradosNoAsignadosPorSeguro(codigoSeguro);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }


        [HttpPost("bulk-upload")]
        public async Task<IActionResult> BulkUploadAsegurados(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No se ha seleccionado ningún archivo.");
            }

            // Guardar el archivo en una ruta temporal en el servidor
            string tempFilePath = Path.GetTempFileName();
            using (FileStream stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            Response response = await _aseguradoService.BulkInsertAsegurados(tempFilePath);

            if (response.Success)
            {
                System.IO.File.Delete(tempFilePath); // Eliminar el archivo temporal después de procesar
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
