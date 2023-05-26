﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Tienda.Datos;
using Tienda.Modelo;

namespace Tienda.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Mproductos>>> Get()
        {
            var function = new Dproductos();
            var lista = await function.MostrarProductos();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Mproductos parametros)
        {
            var funcion = new Dproductos();
            await funcion.InsertarProductos(parametros);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Mproductos parametros)
        {
            var funcion = new Dproductos();
            parametros.id = id;
            await funcion.EditarProductos(parametros);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var funcion = new Dproductos();
            await funcion.EliminarProductos(id);
            return NoContent();
        }
    }
}
