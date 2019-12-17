using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaBlisteria.Models;

namespace LaBlisteria.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Index()
        {
            using (CuentaDbContext db = new CuentaDbContext())
            {
                return View(db.CuentaUsuario.ToList());


            }
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Acceso()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Registro(CuentaUsuario Cuenta)
        {
            if (ModelState.IsValid)
            {
                using (CuentaDbContext db = new CuentaDbContext())
                {
                    db.CuentaUsuario.Add(Cuenta);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = Cuenta.Apellido + " " + Cuenta.Nombre + " Se registro exitosamente.";

            }

            return View();
        }

        [HttpPost]
        public ActionResult Acceso(CuentaUsuario Cuenta)
        {
            using (CuentaDbContext db = new CuentaDbContext())
            {
                var cta = db.CuentaUsuario.Single(c => c.Correo == Cuenta.Correo && c.Contraseña == Cuenta.Contraseña);

                if (cta != null)
                {
                    Session["UsuarioId"] = cta.UsuarioId.ToString();
                    Session["Correo"] = cta.Correo.ToString();
                    return RedirectToAction("Accedido");

                }
                else
                {
                    ModelState.AddModelError("", "Correo o contraseña invalidos"); 



                }
            
            }



                return View();
        }

        public ActionResult Accedido()
        {
            if (Session["UsuarioId"] != null)
            {
                return View();
            }

            return RedirectToAction("Acceso");        }

  

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");


        }   

    }
}