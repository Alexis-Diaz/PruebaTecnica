using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using VentaEN;

namespace VentaDAL
{
    public class VentaDAL
    {
        private ComunDB context = new ComunDB();
        //guardar
        public int GuardarVenta(Venta venta)
        {
            if (venta != null)
            {
                context.Venta.Add(venta);
                return context.SaveChanges();
            }
            return 0;
        }
        //actualizar
        public int ActualizarVenta(Venta venta)
        {
            if (venta != null)
            {
                var ventaEncontrada = context.Venta.Find(venta.IdVenta);
                if (ventaEncontrada != null)
                {
                    ventaEncontrada.Producto = venta.Producto;
                    ventaEncontrada.Descripcion = venta.Descripcion;
                    ventaEncontrada.Precio = venta.Precio;
                    ventaEncontrada.Cantidad = venta.Cantidad;

                    context.Entry(ventaEncontrada).State = System.Data.Entity.EntityState.Modified;
                    return context.SaveChanges();
                }
            }
            return 0;
        }
        //eliminar
        public int EliminarVenta(int? id)
        {
            if (id == null || id == 0)
            {
                return 0;
            }
            var ventaEncontrada = context.Venta.Find(id);
            if (ventaEncontrada != null)
            {
                context.Venta.Remove(ventaEncontrada);
                return context.SaveChanges();
            }
            return 0;
        }
        //buscar por id
        public Venta BuscarVentaPorId(int id)
        {
            if (id > 0)
            {
                return context.Venta.Find(id);
            }
            return null;
        }
        //listar
        public List<Venta> ListarVentas()
        {
            var ventas = context.Venta.ToList();
            return ventas;
        }
    }
}
