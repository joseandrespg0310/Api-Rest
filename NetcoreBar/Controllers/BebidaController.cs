using Microsoft.AspNetCore.Mvc;
using NetcoreBar.Models;
using System.Collections.Generic;

namespace NetcoreBar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidaController : ControllerBase
    {
        private static List<Bebida> bebidas = new List<Bebida>
        {
            new Bebida
            {
                Id = "1",
                Nombre = "Lix",
                Descripcion = "Bebida Alcoholica",
                Precio = 2.50m
            },
            new Bebida
            {
                Id = "2",
                Nombre = "Ron",
                Descripcion = "Que hago con mi vida",
                Precio = 1.00m
            }
        };

        [HttpGet]
        public IEnumerable<Bebida> ListarBebidas()
        {
            return bebidas;
        }

        [HttpGet("{id}")]
        public ActionResult<Bebida> ObtenerBebida(string id)
        {
            var bebida = bebidas.Find(b => b.Id == id);
            if (bebida == null)
            {
                return NotFound();
            }
            return bebida;
        }

        [HttpPost]
        public IActionResult GuardarBebida([FromBody] Bebida nuevaBebida)
        {
            bebidas.Add(nuevaBebida);
            return CreatedAtAction(nameof(ObtenerBebida), new { id = nuevaBebida.Id }, nuevaBebida);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarBebida(string id, [FromBody] Bebida bebidaActualizada)
        {
            var bebida = bebidas.Find(b => b.Id == id);
            if (bebida == null)
            {
                return NotFound();
            }
            bebida.Nombre = bebidaActualizada.Nombre;
            bebida.Descripcion = bebidaActualizada.Descripcion;
            bebida.Precio = bebidaActualizada.Precio;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarBebida(string id)
        {
            var bebida = bebidas.Find(b => b.Id == id);
            if (bebida == null)
            {
                return NotFound();
            }
            bebidas.Remove(bebida);
            return NoContent();
        }
    }
}
