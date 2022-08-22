﻿using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCoderHouseCSharp.Controllers.DTOS;
using ProyectoFinalCoderHouseCSharp.Model;
using ProyectoFinalCoderHouseCSharp.Repository;

namespace ProyectoFinalCoderHouseCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {

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

        //Eliminar Venta
        [HttpDelete("{id}")]
        public bool EliminarVenta([FromBody] int id)
        {
            try
            {
                return VentaHandler.EliminarVenta(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Traer Venta
        [HttpGet]
        public List<Venta> GetVentas()
        {
            return VentaHandler.GetVentas();
        }
    }
}