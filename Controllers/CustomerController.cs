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
            if (TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(context, customer.Email);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg);
                }
            }

            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    context.Customers.Add(customer);
                    
                }
                else
                {
                    context.Customers.Update(customer);
                }
                TempData["alertMessage"] = customer.CustomerId == 0 ?
                    "Customer added successfully" : "Customer updated successfully";
                TempData["alertClass"] = "alert alert-success alert-dismissible";
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
                TempData["alertMessage"] = customer.CustomerId == 0 ?
                    "Customer was not added!" : "Customer was not updated!";
                TempData["alertClass"] = "alert alert-warning alert-dismissible";
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
            }
            return RedirectToAction("Index", "Customer");
        }
    }
}
