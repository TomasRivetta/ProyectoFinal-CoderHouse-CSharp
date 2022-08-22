using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCoderHouseCSharp.Model;
using ProyectoFinalCoderHouseCSharp.Repository;
namespace ProyectoFinalCoderHouseCSharp.Controllers.DTOS
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        //Traer Venta
        [HttpGet]
        public List<Venta> GetVentas()
        {
            return VentaHandler.GetVentas();
        }

        //Cargar Venta
        [HttpPost]
        public bool CargarVenta([FromBody] PostVenta venta)
        {
            try
            {
                return VentaHandler.CargarVenta(new Venta
                {

                    Comentarios = venta.Comentarios,
                    IdUsuario = venta.IdUsuario

                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
