using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_TheDevelopers.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; set; }
        IIncidentRepository Incidents { get; set; }
        IProductRepository Products { get; set; }
        IRegistrationRepository Registrations { get; set; }
        ITechnicianRepository Technicians { get; set; }
        void Complete();
    }
}
