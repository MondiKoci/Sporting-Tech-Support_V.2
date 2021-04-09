using GBCSporting2021_TheDevelopers.Models;
using System.Collections.Generic;
namespace GBCSporting2021_TheDevelopers.IRepositories
{
    public interface IIncidentRepository : IGenericRepository<Incident>
    {
        public List<Incident> GetAllIncidents();
        public List<Incident> GetUnassignedIncidents();
        public List<Incident> GetOpenIncidents();
        public List<Incident> GetIncidentsByTechnician(int id);
    }

}
