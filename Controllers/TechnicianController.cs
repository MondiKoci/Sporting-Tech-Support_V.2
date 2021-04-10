using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using GBCSporting2021_TheDevelopers.IRepositories;
using GBCSporting2021_TheDevelopers.Repositories;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class TechnicianController : Controller
    {
        private SportContext context { get; set; }
        private IUnitOfWork unitOfWork { get; set; }
        public TechnicianController(SportContext scx, IUnitOfWork uw)
        {
            context = scx;
            unitOfWork = uw;
        }
        [Route("[controller]s")]
        public IActionResult Index()
        {
            /*var technicians = context.Technicians
                .OrderBy(t => t.FirstName)
                .ToList();*/
            var technicians = unitOfWork.Technicians.GetAllTechnicians();
            return View(technicians);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool isValid = true;
            //var incidents = context.Incidents.Include(t => t.Technician).ToList();
            var incidents = unitOfWork.Incidents.GetAllIncidents();
            //Technician technician = context.Technicians.Find(id);
            Technician technician = unitOfWork.Technicians.GetTechnicianById(id);
            //ViewBag.Incidents = context.Incidents.Where(i => i.TechnicianId == technician.TechnicianId).ToList();
            ViewBag.Incidents = unitOfWork.Incidents.GetIncidentsByTechnician(id);

            foreach (Incident incident in incidents)
            {
                if (incident.Technician.TechnicianId == technician.TechnicianId)
                {
                    isValid = false;
                }
            }

            if(isValid == true)
            {
                ViewBag.Warning = 0;
            }
            else
            {
                ViewBag.Warning = 1;
            }
            return View(technician);
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            string name = technician.FirstName + " " + technician.LastName;
            bool isValid = true;
            //var incidents = context.Incidents.Include(t => t.Technician).ToList();
            var incidents = unitOfWork.Incidents.GetAllIncidents();
            foreach(Incident incident in incidents)
            {
                if(incident.Technician.TechnicianId == technician.TechnicianId)
                {
                    isValid = false;
                }
            }
            if (isValid == true)
            {
                string[] alerts = Check.alertMessages(true, "deleted", name, "technician");
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                TempData["actionClass"] = "large_div";
                //context.Technicians.Remove(technician);
                //context.SaveChanges();
                unitOfWork.Technicians.Delete(technician);
                unitOfWork.Technicians.Save();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            //var technician = context.Technicians.Find(id);
            var technician = unitOfWork.Technicians.GetTechnicianById(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (technician.TechnicianId == 0)
            {
                //Check if email exists in the database;
                if (TempData["okEmail"] == null)
                {
                    string msg = Check.TechEmailExists(context, technician.Email);
                    if (!String.IsNullOrEmpty(msg))
                    {
                        ModelState.AddModelError(nameof(Customer.Email), msg);
                    }
                }
            }

            string action = technician.TechnicianId == 0 ? "added" : "updated";
            string name = technician.FirstName + " " + technician.LastName;

            if (ModelState.IsValid)
            {
                if (technician.TechnicianId == 0)
                {
                    //context.Technicians.Add(technician);
                    unitOfWork.Technicians.Add(technician);
                }
                else
                {
                    //context.Technicians.Update(technician);
                    unitOfWork.Technicians.Update(technician);
                }
                string[] alerts = Check.alertMessages(true, action, name, "technician");
                TempData["actionClass"] = "large_div";
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                //context.SaveChanges();
                unitOfWork.Technicians.Save();
                return RedirectToAction("Index");
            }
            else
            {
                if (technician.TechnicianId == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                TempData["actionClass"] = "small_div";
                string[] alerts = Check.alertMessages(false, action, name, "technician");
                TempData["alertClass"] = alerts[0];
                TempData["alertMessage"] = alerts[1];
                return View(technician);
            }
        }
    }
}
