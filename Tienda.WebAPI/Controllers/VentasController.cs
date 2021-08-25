using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VentaEN;


namespace Tienda.WebAPI.Controllers
{
    public class VentasController : ApiController
    {
        VentaBL.VentaBL ventaBL = new VentaBL.VentaBL();
        // GET: api/Ventas
        public IEnumerable<VentaEN.Venta> Get()
        {
            return ventaBL.ListarVentas();
        }

        // GET: api/Ventas/5
        public Venta Get(int id)
        {
            return ventaBL.BuscarVentaPorId(id);
        }

        // POST: api/Ventas
        public int Post([FromBody]Venta venta)
        {
            return ventaBL.GuardarVenta(venta);
        }

        // PUT: api/Ventas/5
        public int Put(int id, [FromBody]Venta venta)
        {
            return ventaBL.ActualizarVenta(venta);
        }

        // DELETE: api/Ventas/5
        public int Delete(int id)
        {
            return ventaBL.EliminarVenta(id);
        }
    }
}
