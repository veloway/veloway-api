using Core.DTOs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace veloway_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : Controller
    {
        private readonly IEnvioService envioService;
        public EnviosController(IEnvioService envioService)
        {
            this.envioService = envioService;
        }

        [HttpGet] //localhost:7228/api/envios
        public async Task<IActionResult> getAll()
        {
            try
            {
                var envios = await envioService.getAll();
                //Adaptar el array
                var enviosDto = envios.Adapt<List<EnvioDTO>>();

                return Ok(enviosDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error Interno en el servidor {ex}");
            }
        }


    }
}
