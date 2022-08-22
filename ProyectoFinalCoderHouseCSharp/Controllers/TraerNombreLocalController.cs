using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalCoderHouseCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TraerNombreLocalController : ControllerBase
    {
        [HttpGet]
        public string TraerNombre()
        {
            return "El nombre del Local es: ";
        }

    }
}
