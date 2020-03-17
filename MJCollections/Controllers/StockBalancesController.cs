using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MJCollections.Models;

namespace MJCollections.Controllers
{
    public class StockBalancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockBalances
        public ActionResult Index()
        {
            var stockBalances = db.StockBalances.Include(s => s.Products);
            return View(stockBalances.ToList());
        }

        // GET: StockBalances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockBalance stockBalance = db.StockBalances.Find(id);
            if (stockBalance == null)
            {
                return HttpNotFound();
            }
            return View(stockBalance);
        }

        // GET: StockBalances/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        // POST: StockBalances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockBalanceId,ProductId,Quantity,SellingPrice,Creator,CreateDate")] StockBalance stockBalance)
        {
            if (ModelState.IsValid)
            {
                db.StockBalances.Add(stockBalance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", stockBalance.ProductId);
            return View(stockBalance);
        }

        // GET: StockBalances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockBalance stockBalance = db.StockBalances.Find(id);
            if (stockBalance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", stockBalance.ProductId);
            return View(stockBalance);
        }

        // POST: StockBalances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StockBalanceId,ProductId,Quantity,SellingPrice,Creator,CreateDate")] StockBalance stockBalance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockBalance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", stockBalance.ProductId);
            return View(stockBalance);
        }

        // GET: StockBalances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockBalance stockBalance = db.StockBalances.Find(id);
            if (stockBalance == null)
            {
                return HttpNotFound();
            }
            return View(stockBalance);
        }

        // POST: StockBalances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockBalance stockBalance = db.StockBalances.Find(id);
            db.StockBalances.Remove(stockBalance);
            db.SaveChanges();
            return RedirectToAction("Index");
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
