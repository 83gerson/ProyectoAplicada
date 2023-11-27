using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoofChef.Models;


namespace WoofChef.Controllers
{
    public class ProductController : Controller
    {
        ProyectoApicadaContext _context= new ProyectoApicadaContext();
        // GET: ProductController
        public ActionResult Index()
        {
            var productos = _context.TbProductos.ToList();
            return View(productos);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbProducto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TbProductos.Add(producto);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                ModelState.AddModelError("", "Ocurrió un error al crear el producto.");
            }

            return View(producto);
        }


        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var producto = _context.TbProductos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TbProducto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(producto).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                ModelState.AddModelError("", "Ocurrió un error al editar el producto.");
            }

            return View(producto);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var producto = _context.TbProductos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var producto = _context.TbProductos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.TbProductos.Remove(producto);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
