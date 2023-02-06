using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazinBijuteri.Models;

namespace MagazinBijuteri.Controllers
{
    public class UtilizatorController : Controller
    {
        private UtilizatorDbContext dbCtx = new UtilizatorDbContext();
        // GET: Utilizator
        public ActionResult Index()
        {
            return View(dbCtx.Utilizatori.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            UtilizatorModel user = new UtilizatorModel();
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UtilizatorModel user)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Utilizatori.Add(user);
                dbCtx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(user);
        }



        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            UtilizatorModel user  = dbCtx.Utilizatori.Find(id);
            if (null == user)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UtilizatorModel user)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Entry(user).State = System.Data.Entity.EntityState.Modified;
                dbCtx.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(user);
        }
    }
}