using GBCSporting2021_TheDevelopers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GBCSporting2021_TheDevelopers.IRepositories;
using GBCSporting2021_TheDevelopers.Repositories;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class TechIncidentController : Controller
    {
        public SportContext context;
        public IUnitOfWork unitOfWork;
        public TechIncidentController(SportContext scx, IUnitOfWork uw)
        {
            context = scx;
            unitOfWork = uw;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/techincident")]
        public IActionResult GetTechnician()
        {
            /*var model = new IncidentListViewModel
            {
                TechnicianList = context.Technicians.Select(t => new SelectListItem()
                {
                    Value = t.TechnicianId.ToString(),
                    Text = t.FirstName + " " + t.LastName
                }).ToList()
            };*/
            var model = new IncidentListViewModel
            {
                TechnicianList = unitOfWork.Technicians.GetAllTechnicians().Select(t => new SelectListItem()
                {
                    Value = t.TechnicianId.ToString(),
                    Text = t.FirstName + " " + t.LastName
                }).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult RedirectIncidents(int id)
        {
            return GetIncidents(id);
        }

        [HttpPost]
        public IActionResult GetIncidents(int id)
        {
            var session = new TechnicianSessions(HttpContext.Session);
            //session.setTechnician(context.Technicians.Where(t => t.TechnicianId == id).FirstOrDefault());
            session.setTechnician(unitOfWork.Technicians.GetTechnicianById(id));
            ViewBag.TechName = session.GetTechnician().FirstName + " " + session.GetTechnician().LastName;

            /*var model = new IncidentListViewModel
            {
                Incidents = context.Incidents.Where(i => i.TechnicianId == id).Where(i => i.DateClosed == null).ToList(),
                Technician = context.Technicians.Find(id),
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                TechnicianList = context.Technicians.Select(t => new SelectListItem()
                {
                    Value = t.TechnicianId.ToString(),
                    Text = t.FirstName + " " + t.LastName
                }).ToList()
            };*/

            var model = new IncidentListViewModel
            {
                Incidents = unitOfWork.Incidents.GetIncidentsByTechnician(id),
                Technician = unitOfWork.Technicians.GetTechnicianById(id),
                Customers = unitOfWork.Customers.GetAllCustomers(),
                Products = unitOfWork.Products.GetAllProducts(),
                TechnicianList = unitOfWork.Technicians.GetAllTechnicians().Select(t => new SelectListItem()
                {
                    Value = t.TechnicianId.ToString(),
                    Text = t.FirstName + " " + t.LastName
                }).ToList()
            };

            if (model.Incidents.Count < 1)
            {
                TempData["alertMessage"] = "There are no open incidents for this technician";
            }
            if (id < 1)
            {
                TempData["alertMessage"] = "Please select a Technician";
                return View("GetTechnician", model);
            }

            return View("GetIncidents", model);
        }

        public IActionResult Edit(int id)
        {
            /*var model = new IncidentViewModel
            {
                Incident = context.Incidents.Find(id),
                Customers = context.Customers.ToList(),
                Technicians = context.Technicians.ToList(),
                Products = context.Products.ToList()
            };*/

            var model = new IncidentViewModel
            {
                Incident = unitOfWork.Incidents.GetIncidentById(id),
                Customers = unitOfWork.Customers.GetAllCustomers(),
                Technicians = unitOfWork.Technicians.GetAllTechnicians(),
                Products = unitOfWork.Products.GetAllProducts()
            };

            return View(model);
        }

        //Post for Edit
        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            var session = new TechnicianSessions(HttpContext.Session);
            int techId = session.GetTechnician().TechnicianId;
            //context.Incidents.Update(incident);
            //context.SaveChanges();
            unitOfWork.Incidents.Update(incident);
            unitOfWork.Incidents.Save();

            string[] alerts = Check.alertMessages(true, "edit", "", "incident");
            TempData["actionClass"] = "large_div";
            TempData["alertClass"] = alerts[0];
            TempData["alertMessage"] = alerts[1];
            return GetIncidents(techId);
        }
    }
}
