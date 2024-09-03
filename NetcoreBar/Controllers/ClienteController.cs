using Microsoft.AspNetCore.Mvc;
using NetcoreBar.Models;
using System.Collections.Generic;

namespace NetcoreBar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente
            {
                Id = "1",
                Correo = "google@gmail.com",
                Edad = 21,
                Nombre = "Jose Andres"
            },
            new Cliente
            {
                Id = "2",
                Correo = "g2oogle@gmail.com",
                Edad = 20,
                Nombre = "Luis Andres"
            }
        };

        [HttpGet]
        public IEnumerable<Cliente> ListarClientes()
        {
            return clientes;
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> ObtenerCliente(string id)
        {
            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public IActionResult GuardarCliente([FromBody] Cliente nuevoCliente)
        {
            clientes.Add(nuevoCliente);
            return CreatedAtAction(nameof(ObtenerCliente), new { id = nuevoCliente.Id }, nuevoCliente);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarCliente(string id, [FromBody] Cliente clienteActualizado)
        {
            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.Nombre = clienteActualizado.Nombre;
            cliente.Correo = clienteActualizado.Correo;
            cliente.Edad = clienteActualizado.Edad;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(string id)
        {
            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            clientes.Remove(cliente);
            return NoContent();
        }
    }
}
