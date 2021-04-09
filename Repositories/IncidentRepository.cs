using GBCSporting2021_TheDevelopers.Models;
using GBCSporting2021_TheDevelopers.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace GBCSporting2021_TheDevelopers.Repositories
{
    public class IncidentRepository : GenericRepository<Incident>, IIncidentRepository
    {
        public IncidentRepository(SportContext context) : base(context)
        {
            
        }

        public List<Incident> GetUnassignedIncidents()
        {
            return context.Incidents.Where(i => i.TechnicianId == null).ToList();
        }

       public List<Incident> GetOpenIncidents()
        {
            return context.Incidents.Where(i => i.DateClosed == null).ToList();
        }

        public List<Incident> GetAllIncidents()
        {
            return context.Incidents.ToList();
        }

        public List<Incident> GetIncidentsByTechnician(int id)
        {
            return context.Incidents.Where(i => i.TechnicianId == id).Where(i => i.DateClosed == null).ToList();
        }
    }
}
