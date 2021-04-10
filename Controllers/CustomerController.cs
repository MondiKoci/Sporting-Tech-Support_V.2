using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.EntityFrameworkCore;
using GBCSporting2021_TheDevelopers.IRepositories;
using GBCSporting2021_TheDevelopers.Repositories;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class CustomerController : Controller
    {
        private SportContext context;
        private IUnitOfWork unitOfWork;

        public CustomerController(SportContext scx, IUnitOfWork uw)
        {
            context = scx;
            unitOfWork = uw;
        }
        [Route("/customers")]
        public IActionResult Index()
        {
            /*var customers = context.Customers
                .OrderBy(c => c.FirstName)
                .ToList();*/

            var customers2 = unitOfWork.Customers.GetAllCustomers();
            return View(customers2);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            //ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            //ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Countries = unitOfWork.Countries.GetAllCountries();
            ViewBag.Products = unitOfWork.Products.GetAllProducts();
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            //ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            //ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Countries = unitOfWork.Countries.GetAllCountries();
            ViewBag.Products = unitOfWork.Products.GetAllProducts();
            //var customer = context.Customers.Find(id);
            var customer = unitOfWork.Customers.GetCustomerById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if(customer.CustomerId == 0)
            {
                if(TempData["okEmail"] == null)
                {
                    string msg = Check.EmailExists(context, customer.Email);
                    if (!string.IsNullOrEmpty(msg))
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
                    //context.Customers.Add(customer);
                    unitOfWork.Customers.Add(customer);
                    TempData["actionClass"] = "large_div";
                }
                else
                {
                    //context.Customers.Update(customer);
                    unitOfWork.Customers.Update(customer);
                }
                string[] alerts = Check.alertMessages(true, action, name, "customer");
                TempData["actionClass"] = "large_div";
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                //context.SaveChanges();
                unitOfWork.Customers.Save();
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
                //ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
                TempData["actionClass"] = "small_div";
                string[] alerts = Check.alertMessages(false, action, name, "customer");
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                ViewBag.Countries = unitOfWork.Countries.GetAllCountries();
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool isValid = true;
            //var incidents = context.Incidents.Include(c => c.Customer).ToList();
            var incidents = unitOfWork.Incidents.GetAllIncidents();
            //Customer customer = context.Customers.Find(id);
            Customer customer = unitOfWork.Customers.GetCustomerById(id);
            //ViewBag.Incidents = context.Incidents.Where(i => i.CustomerId == customer.CustomerId).ToList();
            ViewBag.Incidents = unitOfWork.Incidents.GetIncidentByCustomer(customer.CustomerId);

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
            //var incidents = context.Incidents.Include(t => t.Customer).ToList();
            var incidents = unitOfWork.Incidents.GetAllIncidents();
            foreach (Incident incident in incidents)
            {
                if (incident.CustomerId == customer.CustomerId)
                {
                    isValid = false;
                }
            }
            if (isValid == true)
            {
                //context.Customers.Remove(customer);
                //context.SaveChanges();
                unitOfWork.Customers.Delete(customer);
                unitOfWork.Customers.Save();
                string[] alerts = Check.alertMessages(true, "deleted", name, "customer");
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                TempData["actionClass"] = "large_div";
            }
            return RedirectToAction("Index", "Customer");
        }
    }
}
