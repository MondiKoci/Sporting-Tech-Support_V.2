using GBCSporting2021_TheDevelopers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class TechIncidentController : Controller
    {
        public SportContext context;

        public TechIncidentController(SportContext scx)
        {
            context = scx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/techincident")]
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
        public IActionResult RedirectIncidents(int id)
        {
            return GetIncidents(id);
        }

        [HttpPost]
        public IActionResult GetIncidents(int id)
        {
            var session = new TechnicianSessions(HttpContext.Session);
            session.setTechnician(context.Technicians.Where(t => t.TechnicianId == id).FirstOrDefault());
            ViewBag.TechName = session.GetTechnician().FirstName + " " + session.GetTechnician().LastName;
            
            var model = new IncidentListViewModel
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
            };
            
            if(model.Incidents.Count < 1)
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
            var model = new IncidentViewModel
            {
                Incident = context.Incidents.Find(id),
                Customers = context.Customers.ToList(),
                Technicians = context.Technicians.ToList(),
                Products = context.Products.ToList()
            };

            return View(model);
        }

        //Post for Edit
        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            var session = new TechnicianSessions(HttpContext.Session);
            int techId = session.GetTechnician().TechnicianId;
            context.Incidents.Update(incident);
            context.SaveChanges();
            return GetIncidents(techId);
        }
    }
}
