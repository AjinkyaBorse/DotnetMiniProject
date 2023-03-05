using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
    MVCCRUDDBContext1 _context = new MVCCRUDDBContext1();
        public ActionResult Index()
        {
            var listofData = _context.Products.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Product model)
        {

            _context.Products.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data insert Successfully";
            return View();

        }
        [HttpGet]

        public ActionResult Edit(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]

        public ActionResult Edit(Product model)
        {
            var data = _context.Products.Where(x => x.ProductId == model.ProductId).FirstOrDefault();
            if (data != null)
            {

                data.ProductCategory = model.ProductCategory;
                data.Productname = model.Productname;
                data.Productqty = model.Productqty;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            _context.Products.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Successfully";
            return RedirectToAction("index");

        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}