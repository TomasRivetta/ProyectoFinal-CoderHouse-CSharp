﻿using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCoderHouseCSharp.Controllers.DTOS;
using ProyectoFinalCoderHouseCSharp.Model;
using ProyectoFinalCoderHouseCSharp.Repository;

namespace ProyectoFinalCoderHouseCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {

        //Traer Productos
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }

        //Crear Producto
        [HttpPost]
        public bool CrearProducto([FromBody] PostProducto producto)
        {
            try
            {
                return ProductoHandler.CrearProducto(new Producto
                {

                    Descripciones = producto.Descripciones,
                    Costo = producto.Costo,
                    PrecioVenta = producto.PrecioVenta,
                    Stock = producto.Stock,
                    IdUsuario = producto.IdUsuario,

                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        //Modificar un Producto
        [HttpPut]
        public bool ModificarProducto([FromBody] PutProducto producto)
        {
            return ProductoHandler.ModificarProducto(new Producto
            {

                Id = producto.Id,
                Descripciones = producto.Descripciones,
                Costo = producto.Costo,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario,

            });
        }


        //Eliminar un Producto
        [HttpDelete]
        public bool EliminarProducto([FromBody] int id)
        {
            try
            {
                return ProductoHandler.EliminarProducto(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
