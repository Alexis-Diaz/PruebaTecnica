using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaEN;
using VentaBL;

namespace Ventass.UI.Controllers
{
    public class ClientesController : Controller
    {
        private ClienteBL clienteBL = new ClienteBL();
        private ComunDB db = new ComunDB();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = clienteBL.ListarClientes();
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteBL.BuscarClientePorId(Convert.ToInt32(id));
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<Cliente> clientes)
        {
            if (ModelState.IsValid)
            {
                int res = 0;
                foreach (var item in clientes)
                {
                    res += clienteBL.GuardarCliente(item);
                }

                if (res > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("");
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteBL.BuscarClientePorId(Convert.ToInt32(id));

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Nombre,Apellido,Direccion,Telefono")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                int res = clienteBL.ActualizarCliente(cliente);
                if (res > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteBL.BuscarClientePorId(Convert.ToInt32(id));
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int res = clienteBL.EliminarCliente(id);
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
