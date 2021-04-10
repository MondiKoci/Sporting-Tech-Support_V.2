using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class RegistrationController : Controller
    {
        public SportContext context;

        public RegistrationController(SportContext scx)
        {
            context = scx;
        }

        public IActionResult RedirectRegistration(int id)
        {
            return GetRegistrations(id);
        }

        [Route("[controller]s/{id?}")]
        [HttpPost]
        public IActionResult GetRegistrations(int id)
        {
            var session = new RegistrationSession(HttpContext.Session);
            session.SetCustomer(context.Customers.Where(c => c.CustomerId == id).FirstOrDefault());
            ViewBag.Session = session.GetCustomer().FirstName + " " + session.GetCustomer().LastName;
            ViewBag.custId = session.GetCustomer().CustomerId;
           
            List<Product> products = context.Products.ToList();
            foreach (Product prod in context.Products.ToList())
            {
                foreach (Registration reg in context.Registrations.ToList())
                {
                    if(reg.ProductId == prod.ProductId && reg.CustomerId == id)
                    {
                        products.Remove(reg.Product);
                    }
                   
                }
            }

            if(products.Count < 1)
            {
                TempData["Message"] = "There are no products registered for " + ViewBag.Session;
            }

            var model = new RegistrationListViewModel
            {
                Registrations = context.Registrations.Where(r => r.CustomerId == id).ToList(),
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                CustomerList = context.Customers.Where(r => r.CustomerId != id).Select(c => new SelectListItem()
                {
                    Value = c.CustomerId.ToString(),
                    Text = c.FirstName + " " + c.LastName
                }).ToList(),

                ProductList = products.Select(p => new SelectListItem()
                {
                    Value = p.ProductId.ToString(),
                    Text = p.Name
                }).ToList()
            };

            
            return View("GetRegistrations", model);
        }

        [Route("[controller]s")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new RegistrationListViewModel
            {
                Products = context.Products.ToList(),
                Customers = context.Customers.ToList(),
                Registrations = context.Registrations.ToList(),
                CustomerList = context.Customers.Select(c => new SelectListItem()
                {
                    Value = c.CustomerId.ToString(),
                    Text = c.FirstName + " " + c.LastName
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add()
        {
            var session = new RegistrationSession(HttpContext.Session);
            int productId = Convert.ToInt32(Request.Form["productId"]);
            int customerId = session.GetCustomer().CustomerId;
            
            context.Registrations.Add(new Registration {  ProductId = productId, CustomerId = customerId});
            context.SaveChanges();

            string[] alerts = Check.alertMessages(true, "added", "", "product");
            TempData["actionClass"] = "large_div";
            TempData["alertClass"] = alerts[0];
            TempData["alertMessage"] = alerts[1];

            return GetRegistrations(customerId);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Registration reg = context.Registrations.Find(id);
            Product product = context.Products.Where(p => p.ProductId == reg.ProductId).FirstOrDefault();
            Customer customer = context.Customers.Where(c => c.CustomerId == reg.CustomerId).FirstOrDefault();
            ViewBag.delProduct = product.Name;
            ViewBag.delCustomer = customer.FirstName + " " + customer.LastName;
            return View(reg);
        }

        [HttpPost]
        public IActionResult Delete(Registration reg)
        {
            var session = new RegistrationSession(HttpContext.Session);
            int customerId = session.GetCustomer().CustomerId;
            context.Registrations.Remove(reg);
            context.SaveChanges();

            string[] alerts = Check.alertMessages(true, "deleted", "", "product");
            TempData["actionClass"] = "large_div";
            TempData["alertClass"] = alerts[0];
            TempData["alertMessage"] = alerts[1];
            return GetRegistrations(customerId);
        }

    }
}
