using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class RegistrationController : Controller
    {
        public SportContext context;

        //Figure out how to route the ids in the view to Add

        public RegistrationController(SportContext scx)
        {
            context = scx;
        }

        [Route("[controller]s/{id?}")]
        [HttpPost]
        public IActionResult Index(int id)
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
            var model = new RegistrationListViewModel
            {
                Registrations = context.Registrations.Where(r => r.CustomerId == id).ToList(),
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                CustomerList = context.Customers.Select(c => new SelectListItem()
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

            ViewBag.Show = 1;
            return View("Index", model);
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

        
    }
}
