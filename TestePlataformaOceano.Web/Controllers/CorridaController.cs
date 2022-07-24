using Microsoft.AspNetCore.Mvc;
using TestePlaformaOceano.Application;

namespace TestePlataformaOceano.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorridaController : ControllerBase
    {
        private readonly ICorridaApplication _application;
        public CorridaController(ICorridaApplication application)
        {
            _application = application;
        }

        [HttpPost]
        public async Task<IActionResult> ListarCorrida(IFormFile logCorrida)
        {
            try
            {
                return Ok(await _application.BuscarResultadoCorrida(logCorrida));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}