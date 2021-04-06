using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class IncidentListViewModel : IncidentViewModel
    {
        public List<Incident> Incidents { get; set; }
        public Technician Technician { get; set; }
    }
}
