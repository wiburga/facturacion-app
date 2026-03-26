using Microsoft.AspNetCore.Mvc;

namespace FacturacionApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        static List<string> clientes = new List<string>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string nombre)
        {
            clientes.Add(nombre);
            return Ok("Cliente agregado");
        }
    }
}