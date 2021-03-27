using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class CustomerController : Controller
    {
        private SportContext context;

        public CustomerController(SportContext scx)
        {
            context = scx;
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
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
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
                ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
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
