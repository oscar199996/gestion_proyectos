using System.Web.Mvc;
using GestionTareas.Models;
using System.Linq;

namespace GestionTareas.Controllers
{
    public class HomeController : Controller
    {
        private GestionProyectosContext db = new GestionProyectosContext();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Obtener el usuario actual
                var usuario = db.Usuarios.FirstOrDefault(u => u.Email == User.Identity.Name);
                if (usuario != null)
                {
                    ViewBag.NombreUsuario = usuario.Nombre;
                    ViewBag.EsAutenticado = true;

                    // Aquí puedes cargar datos del dashboard
                    // Por ejemplo: tareas pendientes, proyectos, etc.
                    var tareasPendientes = db.Tareas.Where(t => t.AsignadoA == usuario.UsuarioID && t.Estado == "Pendiente").ToList();
                    ViewBag.TareasPendientes = tareasPendientes;
                }
            }
            else
            {
                ViewBag.EsAutenticado = false;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sistema de Gestión de Tareas Diarias";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Información de contacto";
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