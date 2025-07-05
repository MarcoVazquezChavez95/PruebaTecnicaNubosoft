using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.ToList();
            return View(usuarios);
        }

        public ActionResult NuevoUsuario()
        {
            return View("NuevoUsuario", new Usuario());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Usuario model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.FechaRegistro = DateTime.Now;
                    using (var db = new AppDbContext())
                    {
                        db.Usuarios.Add(model);
                        db.SaveChanges();
                        TempData["Mensaje"] = "Usuario registrado correctamente";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Error al registrar al usuario";
                }
            }
            TempData["Mensaje"] = "Error al registrar al usuario";
            return View("NuevoUsuario", model);
        }


        public ActionResult EditarUsuario(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var usuario = db.Usuarios.Find(id);
            if (usuario == null)
                return HttpNotFound();

            return View("NuevoUsuario", usuario); // ← Reutiliza la misma vista
        }

        // POST: Editar usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(Usuario model)
        {
            model.FechaRegistro = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    TempData["Mensaje"] = "Usuario actualizado correctamente";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Error al actualizar usuario";
                }
            }
            TempData["Mensaje"] = "Error al actualizar usuario";
            return View("NuevoUsuario", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminacion(int id)
        {
            var usuario = db.Usuarios.Find(id);
            if (usuario != null)
            {
                try
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Usuario eliminado correctamente.";
                }
                catch
                {
                    TempData["Mensaje"] = "No se encontró el usuario.";
                } 
            }
            else
            {
                TempData["Mensaje"] = "No se encontró el usuario.";
            }

            return RedirectToAction("Index");
        }
    }
}