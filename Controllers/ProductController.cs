using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GBCSporting2021_TheDevelopers.Models;

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
                return View(product);
            }
        }
    }
}
