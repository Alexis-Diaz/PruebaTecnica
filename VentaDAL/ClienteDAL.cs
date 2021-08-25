using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using VentaEN;

namespace VentaDAL
{
    public class ClienteDAL
    {
        private ComunDB context = new ComunDB();
        //guardar
        public int GuardarCliente (Cliente cliente)
        {
            if (cliente != null){
                context.Cliente.Add(cliente);
                return context.SaveChanges();
            }
            return 0;
        }
        //actualizar
        public int ActualizarCliente (Cliente cliente)
        {
            if (cliente != null)
            {
                var clienteEncontrado = context.Cliente.Find(cliente.IdCliente);
                if(clienteEncontrado!= null)
                {
                    clienteEncontrado.Nombre = cliente.Nombre;
                    clienteEncontrado.Apellido = cliente.Apellido;
                    clienteEncontrado.Direccion = cliente.Direccion;
                    clienteEncontrado.Telefono = cliente.Telefono;

                    context.Entry(clienteEncontrado).State = System.Data.Entity.EntityState.Modified;
                    return context.SaveChanges();
                }
            }
            return 0;
        }
        //eliminar
        public int EliminarCliente(int? id)
        {
            if (id == null || id == 0)
            {
                return 0;
            }
            var clienteEncontrado = context.Cliente.Find(id);
            if (clienteEncontrado != null)
            {
                context.Cliente.Remove(clienteEncontrado);
                return context.SaveChanges();
            }
            return 0;
        }
        //buscar por id
        public Cliente BuscarClientePorId(int id)
        {
            if (id > 0)
            {
                return context.Cliente.Find(id);
            }
            return null;
        }
        //listar
        public List<Cliente> ListarClientes()
        {
            var Clientes = context.Cliente.ToList();
            return Clientes;
        }
    }
}
