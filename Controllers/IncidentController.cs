using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using GBCSporting2021_TheDevelopers.IRepositories;
using GBCSporting2021_TheDevelopers.Repositories;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class IncidentController : Controller
    {
        private SportContext context { get; set; }
        private IUnitOfWork unitOfWork { get; set; }
        public IncidentController(SportContext scx, IUnitOfWork uw)
        {
            context = scx;
            unitOfWork = uw;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Incident incident = context.Incidents.Find(id);
            Incident incident = unitOfWork.Incidents.GetIncidentById(id);
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
            //context.Incidents.Remove(incident);
            //context.SaveChanges();
            unitOfWork.Incidents.Delete(incident);
            unitOfWork.Incidents.Save();
            return RedirectToAction("Index");
        }

        [Route("/incidents")]
        public IActionResult Index(string activeFilter = "all")
        {
            //var incs = context.Incidents.OrderBy(i => i.Title).ToList();
            var incs = unitOfWork.Incidents.GetAllIncidents();
           if(activeFilter == "unassigned")
            {
                //incs = context.Incidents.Where(i => i.TechnicianId == null).OrderBy(i => i.Title).ToList();
                incs = unitOfWork.Incidents.GetUnassignedIncidents();
            }
           else if(activeFilter == "open")
            {
                //incs = context.Incidents.Where(i => i.DateClosed == null).OrderBy(i => i.Title).ToList();
                incs = unitOfWork.Incidents.GetOpenIncidents();
            }

            /*var model = new IncidentListViewModel
             {
                 Incidents = incs,
                 Technicians = context.Technicians.ToList(),
                 Customers = context.Customers.ToList(),
                 Products = context.Products.ToList(),
                 ActiveFilter = activeFilter
             };*/

            var model = new IncidentListViewModel
            {
                Incidents = incs,
                Technicians = unitOfWork.Technicians.GetAllTechnicians(),
                Customers = unitOfWork.Customers.GetAllCustomers(),
                Products = unitOfWork.Products.GetAllProducts(),
                ActiveFilter = activeFilter
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            /*var model = new IncidentViewModel
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
            }; */

            var model = new IncidentViewModel
            {
                Incident = new Incident(),
                Customers = unitOfWork.Customers.GetAllCustomers(),
                Technicians = unitOfWork.Technicians.GetAllTechnicians(),
                Products = unitOfWork.Products.GetAllProducts(),
                ActionPage = "Add",
                CustomerList = unitOfWork.Customers.GetAllCustomers().Select(c => new SelectListItem()
                {
                    Value = c.CustomerId.ToString(),
                    Text = c.FirstName + " " + c.LastName
                }).ToList(),
                ProductList = unitOfWork.Products.GetAllProducts().Select(p => new SelectListItem()
                {
                    Value = p.ProductId.ToString(),
                    Text = p.Name
                }).ToList(),
                TechnicianList = unitOfWork.Technicians.GetAllTechnicians().Select(t => new SelectListItem()
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
            /*var model = new IncidentViewModel
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
            }; */

            var model = new IncidentViewModel
            {
                Incident = unitOfWork.Incidents.GetIncidentById(id),
                Customers = unitOfWork.Customers.GetAllCustomers(),
                Technicians = unitOfWork.Technicians.GetAllTechnicians(),
                Products = unitOfWork.Products.GetAllProducts(),
                ActionPage = "Edit",
                CustomerList = unitOfWork.Customers.GetAllCustomers().Select(c => new SelectListItem()
                {
                    Value = c.CustomerId.ToString(),
                    Text = c.FirstName + " " + c.LastName
                }).ToList(),
                ProductList = unitOfWork.Products.GetAllProducts().Select(p => new SelectListItem()
                {
                    Value = p.ProductId.ToString(),
                    Text = p.Name
                }).ToList(),
                TechnicianList = unitOfWork.Technicians.GetAllTechnicians().Select(t => new SelectListItem()
                {
                    Value = t.TechnicianId.ToString(),
                    Text = t.FirstName + " " + t.LastName
                }).ToList()
            };

            //var incident = context.Incidents.Find(id);
            var incident = unitOfWork.Incidents.GetIncidentById(id);
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

                    //context.Incidents.Add(data.Incident);
                    unitOfWork.Incidents.Add(data.Incident);

                }
                else
                {
                    //context.Incidents.Update(data.Incident);
                    unitOfWork.Incidents.Update(data.Incident);
                }
                string[] alerts = Check.alertMessages(true, action, name, "incident");
                TempData["actionClass"] = "large_div";
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                //context.SaveChanges();
                unitOfWork.Incidents.Save();

            }
            return RedirectToAction("Index");

        }
    }
}
