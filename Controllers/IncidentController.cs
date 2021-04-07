using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class IncidentController : Controller
    {
        private SportContext context { get; set; }
        public IncidentController(SportContext scx)
        {
            context = scx;
        }

        [Route("incidents/get")]
        public IActionResult GetTechnician()
        {
            var model = new IncidentListViewModel
            {
                TechnicianList = context.Technicians.Select(t => new SelectListItem()
                {
                    Value = t.TechnicianId.ToString(),
                    Text = t.FirstName + " " + t.LastName
                }).ToList()
            };

            return View(model);
        }

        

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Incident incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            string name = incident.Title;
            string[] alerts = Check.alertMessages(true, "deleted", name, "incident");
            TempData["alertClass"] = alerts[0];
            TempData["alertMessage"] = alerts[1];
            TempData["actionClass"] = "large_div";
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("/incidents")]
        public IActionResult Index()
        {
            var incidents = context.Incidents
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .Include(t => t.Technician)
                .OrderBy(i => i.Title)
                .ToList();
            return View(incidents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new IncidentViewModel
            {
                Incident = new Incident(),
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
                Technicians = context.Technicians.OrderBy(t => t.FirstName).ToList(),
                Products = context.Products.OrderBy(p => p.Name).ToList(),
                ActionPage = "Add",
                CustomerList = context.Customers.Select(c => new SelectListItem()
                {
                    Value = c.CustomerId.ToString(),
                    Text = c.FirstName + " " + c.LastName
                }).ToList(),
                ProductList = context.Products.Select(p => new SelectListItem()
                {
                    Value = p.ProductId.ToString(),
                    Text = p.Name
                }).ToList(),
                TechnicianList = context.Technicians.Select(t => new SelectListItem()
                {
                    Value = t.TechnicianId.ToString(),
                    Text = t.FirstName + " " + t.LastName
                }).ToList()
            };
            return View("Edit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new IncidentViewModel
            {
                Incident = context.Incidents.Find(id),
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
                Technicians = context.Technicians.OrderBy(t => t.FirstName).ToList(),
                Products = context.Products.OrderBy(p => p.Name).ToList(),
                ActionPage = "Edit",
                CustomerList = context.Customers.Select(c => new SelectListItem()
                {
                    Value = c.CustomerId.ToString(),
                    Text = c.FirstName + " " + c.LastName
                }).ToList(),
                ProductList = context.Products.Select(p => new SelectListItem()
                {
                    Value = p.ProductId.ToString(),
                    Text = p.Name
                }).ToList(),
                TechnicianList = context.Technicians.Select(t => new SelectListItem()
                {
                    Value = t.TechnicianId.ToString(),
                    Text = t.FirstName + " " + t.LastName
                }).ToList()
            };

            var incident = context.Incidents.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(IncidentViewModel data)
        {
            string name = data.Incident.Title;
            string action = data.Incident.IncidentId == 0 ? "added" : "deleted";
            if (ModelState.IsValid)
            {
                if (data.ActionPage == "Add")
                {

                    context.Incidents.Add(data.Incident);

                }
                else
                {
                    context.Incidents.Update(data.Incident);
                }
                string[] alerts = Check.alertMessages(true, action, name, "incident");
                TempData["actionClass"] = "large_div";
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                context.SaveChanges();

            }
            return RedirectToAction("Index");
           
        }
    }
}
