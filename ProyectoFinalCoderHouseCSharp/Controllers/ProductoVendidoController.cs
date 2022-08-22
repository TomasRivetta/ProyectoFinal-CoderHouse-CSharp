using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCoderHouseCSharp.Model;
using ProyectoFinalCoderHouseCSharp.Repository;

namespace ProyectoFinalCoderHouseCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        //Traer Productos vendidos
        [HttpGet(Name = "GetProductosVendidos")]
        public List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoHandler.GetProductosVendidos();
        }

        //●	Traer Productos Vendidos: Traer Todos los productos vendidos de un Usuario,
        //cuya información está en su producto (Utilizar dentro de esta función el "Traer Productos"
        //anteriormente hecho para saber que productosVendidos ir a buscar).
        [HttpGet("{idVenta}")]
        public List<ProductoVendido> ProductosVendidos(int idVenta)
        {
            return ProductoVendidoHandler.ProductosVendidos(idVenta);
        }

    }
}
