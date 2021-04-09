using GBCSporting2021_TheDevelopers.Models;
using GBCSporting2021_TheDevelopers.IRepositories;
using System.Linq;
using System.Collections.Generic;

namespace GBCSporting2021_TheDevelopers.Repositories
{
    public class TechnicianRepository : GenericRepository<Technician>, ITechnicianRepository
    {
        public TechnicianRepository(SportContext context) : base(context)
        {

        }

        public List<Technician> GetAllTechnicians()
        {
            return context.Technicians.ToList();
        }
    }
}
