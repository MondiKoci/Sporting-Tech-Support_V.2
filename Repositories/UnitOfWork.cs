using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_TheDevelopers.IRepositories;
using GBCSporting2021_TheDevelopers.Models;

namespace GBCSporting2021_TheDevelopers.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SportContext context;
        public ICustomerRepository Customers { get; set; }
        public IProductRepository Products { get; set; }
        public ITechnicianRepository Technicians { get; set; }
        public IIncidentRepository Incidents { get; set; }
        public IRegistrationRepository Registrations { get; set; }
        public ICountryRepository Countries { get; set; }

        public UnitOfWork(SportContext scx, ICustomerRepository custRepo, IProductRepository prodRepo,
            ITechnicianRepository techRepo, IIncidentRepository incRepo, IRegistrationRepository regRepo, ICountryRepository conRepo)
        {
            context = scx;
            Customers = custRepo;
            Products = prodRepo;
            Technicians = techRepo;
            Incidents = incRepo;
            Registrations = regRepo;
            Countries = conRepo;
        }

        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
