using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaEN;

namespace VentaBL
{
    public class VentaBL
    {
        private VentaDAL.VentaDAL ventaDAL = new VentaDAL.VentaDAL();
        //guardar
        public int GuardarVenta(Venta venta)
        {
            return ventaDAL.GuardarVenta(venta);
        }
        //modificar
        public int ActualizarVenta(Venta venta)
        {
            return ventaDAL.ActualizarVenta(venta);
        }
        //eliminar
        public int EliminarVenta(int? id)
        {
            return ventaDAL.EliminarVenta(id);
        }
        //buscar por id
        public Venta BuscarVentaPorId(int id)
        {
            return ventaDAL.BuscarVentaPorId(id);
        }
        //listar
        public List<Venta> ListarVentas()
        {
            return ventaDAL.ListarVentas();
        }

    }
}
