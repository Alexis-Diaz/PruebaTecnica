using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using VentaDAL;
using VentaEN;

namespace VentaBL
{
    public class ClienteBL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();
        //guardar
        public int GuardarCliente(Cliente cliente)
        {
            return clienteDAL.GuardarCliente(cliente);
        }
        //modificar
        public int ActualizarCliente(Cliente cliente)
        {
            return clienteDAL.ActualizarCliente(cliente);
        }
        //eliminar
        public int EliminarCliente(int? id)
        {
            return clienteDAL.EliminarCliente(id);
        }
        //buscar por id
        public Cliente BuscarClientePorId(int id)
        {
            return clienteDAL.BuscarClientePorId(id);
        }
        //listar
        public List<Cliente> ListarClientes()
        {
            return clienteDAL.ListarClientes();
        }
    }
}
