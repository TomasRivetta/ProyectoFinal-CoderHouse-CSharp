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
        [HttpGet(Name = "TodosLosProductosVendidos")]
        public List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoHandler.GetProductosVendidos();
        }

        //Traer Productos vendidos de cierto Usuario
        [HttpGet("{idVenta}")]
        public List<ProductoVendido> ProductosVendidos(int idVenta)
        {
            return ProductoVendidoHandler.ProductosVendidos(idVenta);
        }
    }
}
