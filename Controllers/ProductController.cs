using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class ProductController : Controller
    {
        private SportContext context { get; set; }

        public ProductController(SportContext scx)
        {
            context = scx;
        }
        [Route("/products")]
        public IActionResult Index()
        {
            var products = context.Products
                .OrderBy(p => p.Name)
                .ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            string name = product.Name;
            string[] alerts = Check.alertMessages(true, "deleted", name, "product");
            TempData["alertClass"] = alerts[0];
            TempData["alertMessage"] = alerts[1];
            TempData["actionClass"] = "large_div";
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            string name = product.Name;
            string action = product.ProductId == 0 ? "added" : "deleted";
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    context.Products.Add(product);
                }
                else
                {
                    context.Products.Update(product);
                }
                string[] alerts = Check.alertMessages(true, action, name, "product");
                TempData["actionClass"] = "large_div";
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                if (product.ProductId == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                TempData["actionClass"] = "small_div";
                string[] alerts = Check.alertMessages(false, action, name, "product");
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                return View(product);
            }
        }
    }
}
