using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WoofChef.Models;

namespace WoofChef.Controllers
{
    public class LoginController : Controller
    {
        ProyectoApicadaContext _context = new ProyectoApicadaContext();
        // GET: LoginController
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Verification(string nombreUsuario, string contrasennia)
        {
            var usuarioEncontrado = _context.TbUsuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasenna == contrasennia);

            if (usuarioEncontrado != null)
            {
                // Iniciar sesión y redirigir a la página de inicio
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Mostrar mensaje de error y regresar a la vista de inicio de sesión
                ViewBag.ErrorMessage = "Credenciales de inicio de sesión incorrectas";
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
