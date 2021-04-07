using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class CustomerController : Controller
    {
        private SportContext context;
        private List<SelectListItem> CountriesList;
        
        public CustomerController(SportContext scx)
        {
            context = scx;
            CountriesList = context.Countries.OrderBy(c => c.Name).Select(c => new SelectListItem()
            {
                Value = c.CountryId.ToString(),
                Text = c.Name
            }).ToList();
        }
        [Route("/customers")]
        public IActionResult Index()
        {
            var customers = context.Customers
                .OrderBy(c => c.FirstName)
                .ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = CountriesList;
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = CountriesList;
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if(customer.CustomerId == 0)
            {
                //Check if email exists in the database;
                if (TempData["okEmail"] == null)
                {
                    string msg = Check.EmailExists(context, customer.Email);
                    if (!String.IsNullOrEmpty(msg))
                    {
                        ModelState.AddModelError(nameof(Customer.Email), msg);
                    }
                }
            }
            
            string action = customer.CustomerId == 0 ? "added" : "updated";
            string name = customer.FirstName + " " + customer.LastName;
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    context.Customers.Add(customer);
                    TempData["actionClass"] = "large_div";

                }
                else
                {
                    context.Customers.Update(customer);
                }
                string[] alerts = Check.alertMessages(true, action, name, "customer");
                TempData["actionClass"] = "large_div";
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                if (customer.CustomerId == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                TempData["actionClass"] = "small_div";
                string[] alerts = Check.alertMessages(false, action, name, "customer");
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                ViewBag.Countries = CountriesList;
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool isValid = true;
            var incidents = context.Incidents.Include(c => c.Customer).ToList();
            Customer customer = context.Customers.Find(id);
            ViewBag.Incidents = context.Incidents.Where(i => i.CustomerId == customer.CustomerId).ToList();

            foreach (Incident incident in incidents)
            {
                if (incident.Customer.CustomerId == customer.CustomerId)
                {
                    isValid = false;
                }
            }

            if (isValid == true)
            {
                ViewBag.Warning = 0;
            }
            else
            {
                ViewBag.Warning = 1;
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            string name = customer.FirstName + " " + customer.LastName;
            bool isValid = true;
            var incidents = context.Incidents.Include(t => t.Customer).ToList();
            foreach (Incident incident in incidents)
            {
                if (incident.CustomerId == customer.CustomerId)
                {
                    isValid = false;
                }
            }
            if (isValid == true)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
                string[] alerts = Check.alertMessages(true, "deleted", name, "customer");
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                TempData["actionClass"] = "large_div";
            }
            return RedirectToAction("Index", "Customer");
        }
    }
}
