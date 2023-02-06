using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazinBijuteri.Models;
using MagazinDeBijuteriiPROIECTFINAL.Models;
using Microsoft.Ajax.Utilities;

namespace MagazinDeBijuteriiPROIECTFINAL.Controllers
{
    public class ProdusController : Controller
    {
        private ProdusContext dbCtx = new ProdusContext();
        private CosCumparaturiDbContext cosdb = new CosCumparaturiDbContext();

        // GET: Produs
        public ActionResult Index()
        {
           
            return View(dbCtx.Produse.ToList());
        }

        public ActionResult Create()
        {
            ProdusModel std = new ProdusModel();
            std.ProdusId = 0;
            std.Denumire = "";
            std.Descriere = "";
            std.Cantitate = 0;
            std.Pret = 0.0;


            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdusModel prod)
        {
            if (ModelState.IsValid)
            {
                dbCtx.Produse.Add(prod);
                dbCtx.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(prod);
        }

        public ActionResult AddToCart(int? id)
        {
            if (!id.HasValue)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            ProdusModel p = dbCtx.Produse.Find(id);
            if (null == p)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        [HttpPost, ActionName("Add to cart")]
        public ActionResult AddToCart(int id)
        {
            if (ModelState.IsValid)
            {

                ProdusModel p = dbCtx.Produse.Find(id);
                CosCumparaturi cos = new CosCumparaturi();
                cos.ProdusId = p.ProdusId;
                cos.Denumire = p.Denumire;
                cos.Descriere = p.Descriere;
                cos.Cantitate = 1;
                cos.Pret = p.Pret + cos.Cantitate;
                cosdb.Cos.Add(cos);
                cosdb.SaveChanges();

            }
            
            return RedirectToAction("Index");

        }

        

        [ActionName("Details")]
        public ActionResult Details(int id)
        {

            ProdusModel p = dbCtx.Produse.Find(id);
            if (null == p)
            {
                return HttpNotFound();
            }

            return View(p);
        }

    }
}