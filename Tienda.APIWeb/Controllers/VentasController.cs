using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using VentaEN;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Tienda.APIWeb.Controllers
{
    public class VentasController : ApiController
    {
        VentaBL.VentaBL ventaBL = new VentaBL.VentaBL();
        // GET: api/Ventas
        public string Get()
        {
            
            List<Venta> lista = ventaBL.ListarVentas();
            string listaJson = JsonConvert.SerializeObject(lista, Formatting.Indented);
            return listaJson;
        }

        // GET: api/Ventas/5
        public string Get(int id)
        {
            Venta venta = ventaBL.BuscarVentaPorId(id);
            string ventaJson = JsonConvert.SerializeObject(venta, Formatting.Indented);
            return ventaJson;
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
