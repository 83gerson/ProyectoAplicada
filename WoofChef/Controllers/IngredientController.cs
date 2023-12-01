using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoofChef.Models;

namespace WoofChef.Controllers
{
    public class IngredientController : Controller
    {
        ProyectoApicadaContext _context = new ProyectoApicadaContext();
        // GET: IngrdientController
        public ActionResult Index()
        {
            var ingredientes = _context.TbIngredientes.ToList();
            return View(ingredientes);
        }

        // GET: IngrdientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IngrdientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngrdientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbIngrediente tbIngrediente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TbIngredientes.Add(tbIngrediente);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                ModelState.AddModelError("", "Ocurrió un error al crear el producto.");
            }

            return View(tbIngrediente);
        }

        // GET: IngrdientController/Edit/5
        public ActionResult Edit(int id)
        {
            var ingrediente = _context.TbIngredientes.Find(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }

        // POST: IngrdientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TbIngrediente tbIngrediente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(tbIngrediente).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                ModelState.AddModelError("", "Ocurrió un error al editar el producto.");
            }

            return View(tbIngrediente);
        }

        // GET: IngrdientController/Delete/5
        public ActionResult Delete(int id)
        {
            var ingrediente = _context.TbIngredientes.Find(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }

        // POST: IngrdientController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ingrediente = _context.TbIngredientes.Find(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            _context.TbIngredientes.Remove(ingrediente);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
