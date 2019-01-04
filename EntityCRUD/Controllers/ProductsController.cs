using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityCRUD.Models;
using System.Net;
    

namespace EntityCRUD.Controllers
{
    public class ProductsController : Controller
    {
        ProductsConnection db = new ProductsConnection();

        public ViewResult Index()
        {
            return View(db.ProductsTable.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");

            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(product);
        }
        public ViewResult Create()
        {

            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost()
        {
            if(ModelState.IsValid)
            {
                Product product = new Product();
                TryUpdateModel(product);
                db.ProductsTable.Add(product);
                db.SaveChanges();
            }
              return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");
            }
            Product product = db.ProductsTable.Find(id);
            if(product==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product not found");
            }
            return View(product);
  
        }
        [HttpPost]
        [ActionName("Edit")]

        public ActionResult Edit(int id)
        {
            Product product = db.ProductsTable.Single(x => x.ProductId == id);
            UpdateModel(product);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id Required");
            }
            Product product = db.ProductsTable.Find(id);
            if(product==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product not found");
            }
            return View(product);

        }
        [HttpPost]
        [ActionName("Delete")]
         public ActionResult Delete(int id)
        {
            Product product = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");









            


        }




    }
}