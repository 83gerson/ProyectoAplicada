using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoofChef.Models;

namespace WoofChef.Controllers
{
    public class ExpedienteController : Controller
    {
        ProyectoApicadaContext _context = new ProyectoApicadaContext();
        // GET: ExpedienteController
        public ActionResult Index()
        {
            var expedientes = _context.TbExpedientes.ToList();
            return View(expedientes);
        }

        // GET: ExpedienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpedienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpedienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbExpediente tbExpediente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TbExpedientes.Add(tbExpediente);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                ModelState.AddModelError("", "Ocurrió un error al crear el producto.");
            }

            return View(tbExpediente);
        }

        // GET: ExpedienteController/Edit/5
        public ActionResult Edit(int id)
        {
            var expediente = _context.TbExpedientes.Find(id);

            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // POST: ExpedienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TbExpediente expediente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(expediente).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                ModelState.AddModelError("", "Ocurrió un error al editar el producto.");
            }

            return View(expediente);
        }

        // GET: ExpedienteController/Delete/5
        public ActionResult Delete(int id)
        {
            var expediente = _context.TbExpedientes.Find(id);

            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // POST: ExpedienteController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var expediente = _context.TbExpedientes.Find(id);

            if (expediente == null)
            {
                return NotFound();
            }

            _context.TbExpedientes.Remove(expediente);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
