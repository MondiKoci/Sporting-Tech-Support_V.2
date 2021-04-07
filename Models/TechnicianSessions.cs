using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class TechnicianSessions
    {
        private const string TechniciansKey = "myTechnicians";

        private ISession session { get; set; }
        public TechnicianSessions(ISession session)
        {
            this.session = session;
        }

        public void setTechnician(Technician technician)
        {
            session.SetObject(TechniciansKey, technician);
        }
        public Technician GetTechnician()
        {
            return session.GetObject<Technician>(TechniciansKey) ?? new Technician();
        }

        public void RemoveTechnician()
        {
            session.Remove(TechniciansKey);
        }
    }
}
