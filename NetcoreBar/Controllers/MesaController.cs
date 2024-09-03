using Microsoft.AspNetCore.Mvc;
using NetcoreBar.Models;
using System.Collections.Generic;

namespace NetcoreBar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesaController : ControllerBase
    {
        private static List<Mesa> mesas = new List<Mesa>
        {
            new Mesa
            {
                Id = "1",
                Capacidad = 4,
                Precio = 50.00m,
                Hora = DateTime.Now
            },
            new Mesa
            {
                Id = "2",
                Capacidad = 2,
                Precio = 30.00m,
                Hora = DateTime.Now.AddHours(-1)
            }
        };

        [HttpGet]
        public IEnumerable<Mesa> ListarMesas()
        {
            return mesas;
        }

        [HttpGet("{id}")]
        public ActionResult<Mesa> ObtenerMesa(string id)
        {
            var mesa = mesas.Find(m => m.Id == id);
            if (mesa == null)
            {
                return NotFound();
            }
            return mesa;
        }

        [HttpPost]
        public IActionResult GuardarMesa([FromBody] Mesa nuevaMesa)
        {
            mesas.Add(nuevaMesa);
            return CreatedAtAction(nameof(ObtenerMesa), new { id = nuevaMesa.Id }, nuevaMesa);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarMesa(string id, [FromBody] Mesa mesaActualizada)
        {
            var mesa = mesas.Find(m => m.Id == id);
            if (mesa == null)
            {
                return NotFound();
            }
            mesa.Capacidad = mesaActualizada.Capacidad;
            mesa.Precio = mesaActualizada.Precio;
            mesa.Hora = mesaActualizada.Hora;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarMesa(string id)
        {
            var mesa = mesas.Find(m => m.Id == id);
            if (mesa == null)
            {
                return NotFound();
            }
            mesas.Remove(mesa);
            return NoContent();
        }
    }
}
