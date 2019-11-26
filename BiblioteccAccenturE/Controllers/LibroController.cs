using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiblioteccAccenturE.Models;

namespace BiblioteccAccenturE.Controllers
{
    public class LibroController : Controller
    {
        private BiblioteccAccenturEEntities dbLibro;

        public LibroController()
        {
            this.dbLibro = new BiblioteccAccenturEEntities();
        }
        public ActionResult ListadoLibros()
        {
            List<Libro> libros = this.dbLibro.Libro.ToList();
            return View(libros);
        }

        public ActionResult AgregarLibro()
        {
            this.ViewBag.TituloPagina = "Agregar Libro";
            Libro lib = new Libro();
            return View("EditarLibro", lib);
        }

        [HttpPost]
        public ActionResult AgregarLibro(Libro lib)
        {
            this.ViewBag.TituloPagina = "Agregar Libro";
            this.dbLibro.Libro.Add(lib);
            this.dbLibro.SaveChanges();
            return RedirectToAction("ListadoLibros");
        }


        public ActionResult EditarLibro(int id)
        {
            this.ViewBag.TituloPagina = "Editar Libro";
            Libro lib = this.dbLibro.Libro.Find(id);
            return View(lib);
        }

        [HttpPost]
        public ActionResult EditarLibro(Libro lib)
        {
            this.ViewBag.TituloPagina = "Editar Libro";
            this.dbLibro.Libro.Attach(lib);
            this.dbLibro.Entry(lib).State = System.Data.Entity.EntityState.Modified;
            this.dbLibro.SaveChanges();
            return RedirectToAction("ListadoLibros");
        }


        public ActionResult EliminarLibro(int id)
        {
            Libro lib = this.dbLibro.Libro.Find(id);
            this.dbLibro.Libro.Remove(lib);
            this.dbLibro.SaveChanges();
            return RedirectToAction("ListadoLibros");
        }
    }
}