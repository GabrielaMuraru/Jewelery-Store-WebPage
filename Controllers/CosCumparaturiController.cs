using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using MagazinBijuteri.Models;
using MagazinDeBijuteriiPROIECTFINAL.Models;

namespace MagazinBijuteri.Controllers
{
    public class CosCumparaturiController : Controller
    {
        private CosCumparaturiDbContext dbCtx = new CosCumparaturiDbContext();
        // GET: CosCumparaturi
        public ActionResult Index()
        {
            return View(dbCtx.Cos.ToList());
        }

        public ActionResult Create()
        {
            CosCumparaturi cos = new CosCumparaturi();
            cos.ProdusId = 0;
            cos.Denumire = "";
            cos.Descriere = "";
            cos.Cantitate = 0;
            cos.Pret *= cos.Cantitate;
            return View(cos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CosCumparaturi c)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Cos.Add(c);
                dbCtx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(c);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            CosCumparaturi cos = dbCtx.Cos.Find(id);
            if (null == cos)
            {
                return HttpNotFound();
            }
            return View(cos);
        }

        [HttpPost]
        public ActionResult Edit(CosCumparaturi cos)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Entry(cos).State = System.Data.Entity.EntityState.Modified;
                dbCtx.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(cos);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            CosCumparaturi cos = dbCtx.Cos.Find(id); 
            if (null == cos)
            {
                return HttpNotFound();
            }
            return View(cos);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                CosCumparaturi cos = dbCtx.Cos.Find(id);
                dbCtx.Cos.Remove(cos);
                dbCtx.SaveChanges();

            }
            return RedirectToAction("Index");

        }

        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            CosCumparaturi cos = dbCtx.Cos.Find(id);
            if (null == cos)
            {
                return HttpNotFound();
            }

            return View(cos);
        }
    }
}