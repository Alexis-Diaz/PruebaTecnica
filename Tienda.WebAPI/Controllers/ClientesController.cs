using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using VentaBL;
using VentaEN;

namespace Tienda.WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        ClienteBL clienteBL = new ClienteBL();
        // GET: api/Clientes
        public IEnumerable<Cliente> Get()
        {
            return clienteBL.ListarClientes();
        }

        // GET: api/Clientes/5
        public Cliente Get(int id)
        {
            return clienteBL.BuscarClientePorId(id);
        }

        // POST: api/Clientes
        public int Post([FromBody]Cliente cliente)
        {
            return clienteBL.GuardarCliente(cliente);
        }

        // PUT: api/Clientes/5
        public int Put(int id, [FromBody]Cliente cliente)
        {
            return clienteBL.ActualizarCliente(cliente);
        }

        // DELETE: api/Clientes/5
        public int Delete(int id)
        {
            return clienteBL.EliminarCliente(id);
        }
    }
}
