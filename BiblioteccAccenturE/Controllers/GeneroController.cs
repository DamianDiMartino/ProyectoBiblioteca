﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiblioteccAccenturE.Models;

namespace BiblioteccAccenturE.Controllers
{
    public class GeneroController : Controller
    {
        private BiblioteccAccenturEEntities dbGenero;

        public GeneroController()
        {
            this.dbGenero = new BiblioteccAccenturEEntities();
        }
        public ActionResult ListadoGeneros()
        {
            List<Genero> generos = this.dbGenero.Genero.ToList();
            return View(generos);

        }

        public ActionResult AgregarGenero()
        {
            this.ViewBag.TituloPagina = "Agregar Genero";
            Genero gen = new Genero();
            return View("Editar", gen);
        }

        [HttpPost]
        public ActionResult AgregarGenero(Genero gen)
        {
            this.ViewBag.TituloPagina = "Agregar Genero";
            this.dbGenero.Genero.Add(gen);
            this.dbGenero.SaveChanges();
            return RedirectToAction("ListadoGeneros");
        }


        public ActionResult EditarGenero(int id)
        {
            this.ViewBag.TituloPagina = "Editar Genero";
            Genero gen = this.dbGenero.Genero.Find(id);
            return View(gen);
        }

        [HttpPost]
        public ActionResult EditarGenero(Genero gen)
        {
            this.ViewBag.TituloPagina = "Editar Genero";
            this.dbGenero.Genero.Attach(gen);
            this.dbGenero.Entry(gen).State = System.Data.Entity.EntityState.Modified;
            this.dbGenero.SaveChanges();
            return RedirectToAction("ListadoGeneros");
        }


        public ActionResult EliminarGenero(int id)
        {
            Genero gen = this.dbGenero.Genero.Find(id);
            this.dbGenero.Genero.Remove(gen);
            this.dbGenero.SaveChanges();
            return RedirectToAction("ListadoGeneros");
        }
    }
}