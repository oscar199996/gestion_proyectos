using System.Web.Mvc;
using System.Web.Security;
using GestionTareas.Models;
using System.Linq;

namespace GestionTareas.Controllers
{
    public class AccountController : Controller
    {
        private GestionProyectosContext db = new GestionProyectosContext();

        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string contraseña, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.Email == email && u.Contraseña == contraseña && u.Estado);

                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.Email, false);
                    Session["UsuarioID"] = usuario.UsuarioID;
                    Session["NombreUsuario"] = usuario.Nombre;

                    TempData["SuccessMessage"] = $"¡Bienvenido/a de nuevo {usuario.Nombre}! 👋";

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Email o contraseña incorrectos";
                }
            }
            return View();
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        // POST: /Account/Register
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (db.Usuarios.Any(u => u.Email == usuario.Email))
                {
                    ModelState.AddModelError("Email", "Este email ya está registrado");
                    return View(usuario);
                }

                db.Usuarios.Add(usuario);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(usuario.Email, false);
                Session["UsuarioID"] = usuario.UsuarioID;
                Session["NombreUsuario"] = usuario.Nombre;

                // Mensaje de éxito
                TempData["SuccessMessage"] = $"¡Bienvenido/a {usuario.Nombre}! Tu cuenta ha sido creada exitosamente. 🎉";

                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }

        // GET: /Account/RegistrationSuccess
        public ActionResult RegistrationSuccess(string nombre)
        {
            ViewBag.Nombre = nombre;
            return View();
        }
        // GET: /Account/Logout (solo un método)
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
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