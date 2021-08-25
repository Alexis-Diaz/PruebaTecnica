using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaEN;

namespace Ventass.UI.Controllers
{
    public class VentasController : Controller
    {
        private VentaBL.VentaBL ventaBL = new VentaBL.VentaBL();
        private ComunDB db = new ComunDB();

        // GET: Ventas
        public ActionResult Index()
        {
            var ventas = ventaBL.ListarVentas();
            return View(ventas);
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = ventaBL.BuscarVentaPorId(Convert.ToInt32(id));
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<Venta> venta, int IdCliente, string [] precios)
        {
            int res = 0;
            int i = 0;
            foreach(var item in venta)
            {
                if(item != null)
                {
                    item.IdCliente = IdCliente;
                    decimal precio;
                    bool isDecimal = decimal.TryParse(precios[i], out precio);
                    if (!isDecimal)
                    {
                        continue;
                    }
                    item.Precio = precio;
                    if (!string.IsNullOrEmpty(item.Producto)&& item.Precio > 0 && !string.IsNullOrEmpty(item.Descripcion) && item.Cantidad > 0)
                    {
                        res += ventaBL.GuardarVenta(item);
                    }
                }
                i++;
            }
           
            if(res > 0)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Precios = precios;
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", venta[0].IdCliente);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = ventaBL.BuscarVentaPorId(Convert.ToInt32(id));
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", venta.IdCliente);
            ViewBag.Precio = venta.Precio;
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVenta,Producto,Descripcion,Precio,Cantidad,IdCliente")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                int res = ventaBL.ActualizarVenta(venta);
                if (res > 0)
                {
                    return RedirectToAction("Index");

                }
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", venta.IdCliente);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = ventaBL.BuscarVentaPorId(Convert.ToInt32(id));
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int res = ventaBL.EliminarVenta(id);
            if (res > 0)
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
