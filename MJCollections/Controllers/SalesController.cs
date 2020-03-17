using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MJCollections.Models;
using System.IO;

namespace MJCollections.Controllers
{
    public class SalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Products);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }


      

        public ActionResult Requests(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }



        // GET: Sales/Create
        public ActionResult Create()
        {
            //ViewBag.PicturesId = new SelectList(db.Pictures, "PicturesId", "ProductImage");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesId,SaleTitle,Date,Quantity,ProductId,UnitPrice,Phone,Comment,Pictures,Status,Creator,CreateDate,UserIdN")] Sales sales, HttpPostedFileBase Pictures)
        {
            if (ModelState.IsValid)
            {

                if (Pictures != null)
                {
                    string fileExtension = Path.GetExtension(Pictures.FileName).ToLower();
                    string file = Path.GetFileName(DateTime.UtcNow.Ticks + fileExtension);
                    string path = Path.Combine(Server.MapPath("~/Images/"), file);
                    if (fileExtension.Equals(".jpg") || fileExtension.Equals(".gif") || fileExtension.Equals(".png"))
                    {
                        Pictures.SaveAs(path);
                        sales.Pictures = file;
                        db.Sales.Add(sales);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                //else
                //{
                //    TempData["Error"] = "You have uploaded an invalid file format, please ensure you upload a valid file format!";
                //}




                //db.Sales.Add(sales);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //ViewBag.PicturesId = new SelectList(db.Pictures, "PicturesId", "ProductImage", sales.PicturesId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", sales.ProductId);
            return View(sales);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            //ViewBag.PicturesId = new SelectList(db.Pictures, "PicturesId", "ProductImage", sales.PicturesId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", sales.ProductId);
            return View(sales);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesId,SaleTitle,Date,Quantity,ProductId,UnitPrice,Phone,Comment,Pictures,Status,Creator,CreateDate,UserIdN")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.PicturesId = new SelectList(db.Pictures, "PicturesId", "ProductImage", sales.PicturesId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", sales.ProductId);
            return View(sales);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales sales = db.Sales.Find(id);
            db.Sales.Remove(sales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Order([Bind(Include = "OrderId,SalesId,Quantity,Phone,Color,Others,Total,Creator,CreateDate,UserIdN")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                var sale = db.Sales.Where(x => x.SalesId == order.SalesId).FirstOrDefault();
                var stockBalance = db.StockBalances.Where(x => x.ProductId == sale.ProductId).FirstOrDefault();
                if (stockBalance != null)
                {
                    if ((stockBalance.Quantity - order.Quantity) >= 0)
                    {
                        stockBalance.Quantity -= order.Quantity;
                        db.Entry(stockBalance).State = EntityState.Modified;
                        var sales = db.Sales.Where(x => x.SalesId == order.SalesId).FirstOrDefault();
                        order.Total += (stockBalance.SellingPrice * order.Quantity);
                        db.Entry(sales).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        TempData["Message"] = "The product is either out of stock or the quatity requested for cannot be provided. The quantity available in stock is " + stockBalance.Quantity;
                    }
                }
                else
                {
                    TempData["Message"] = "This item has never been stocked in this store!";
                }
                return RedirectToAction("Requests", "Sales", new { id = order.SalesId });
            }

            ViewBag.SalesId = new SelectList(db.Sales, "SalesId", "SaleTitle", order.SalesId);
            return View(order);
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
