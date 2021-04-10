using GBCSporting2021_TheDevelopers.Models;
using System.Collections.Generic;
namespace GBCSporting2021_TheDevelopers.IRepositories
{
    public interface ITechnicianRepository : IGenericRepository<Technician>
    {
        public List<Technician> GetAllTechnicians();
        public Technician GetTechnicianById(int id);
    }
}
