﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiblioteccAccenturE.Models;

namespace BiblioteccAccenturE.Controllers
{
    public class EditorialController : Controller
    {
        private BiblioteccAccenturEEntities dbEditorial;
        
        public EditorialController()
        {
            this.dbEditorial = new BiblioteccAccenturEEntities();
        }
        public ActionResult ListadoEditoriales()
        {
            List<Editorial> editoriales = this.dbEditorial.Editorial.ToList();
            return View(editoriales);
        }

        public ActionResult AgregarEditorial()
        {
            this.ViewBag.TituloPagina = "Agregar Editorial";
            Editorial edit = new Editorial();
            return View("EditarEditorial", edit);
        }

        [HttpPost]
        public ActionResult AgregarEditorial(Editorial edit)
        {
            this.ViewBag.TituloPagina = "Agregar Editorial";
            this.dbEditorial.Editorial.Add(edit);
            this.dbEditorial.SaveChanges();
            return RedirectToAction("ListadoEditoriales");
        }


        public ActionResult EditarEditorial(int id)
        {
            this.ViewBag.TituloPagina = "Editar Editorial";
            Editorial edit = this.dbEditorial.Editorial.Find(id);
            return View(edit);
        }

        [HttpPost]
        public ActionResult EditarEditorialr(Editorial edit)
        {
            this.ViewBag.TituloPagina = "Editar Autor";
            this.dbEditorial.Editorial.Attach(edit);
            this.dbEditorial.Entry(edit).State = System.Data.Entity.EntityState.Modified;
            this.dbEditorial.SaveChanges();
            return RedirectToAction("ListadoEditoriales");
        }


        public ActionResult EliminarEditorial(int id)
        {
            Editorial edit = this.dbEditorial.Editorial.Find(id);
            this.dbEditorial.Editorial.Remove(edit);
            this.dbEditorial.SaveChanges();
            return RedirectToAction("ListadoEditoriales");
        }
    }
}