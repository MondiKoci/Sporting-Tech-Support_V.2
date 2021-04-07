using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class Check
    {
        public static string EmailExists(SportContext context, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                var customer = context.Customers.FirstOrDefault(
                    c => c.Email.ToLower() == email.ToLower());
                if (customer != null)
                    msg = $"Email address {email} already in use.";
            }
            return msg;
        }
        public static string TechEmailExists(SportContext context, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                var customer = context.Technicians.FirstOrDefault(
                    t => t.Email.ToLower() == email.ToLower());
                if (customer != null)
                    msg = $"Email address {email} already in use.";
            }
            return msg;

        }

        //Alert Message validation
        public static string[] alertMessages(bool success, string action, string name, string type)
        {
            string[] tempAlerts = new string[2];
            if (success)
            {
                tempAlerts[0] = "alert alert-success alert-dismissible";
                tempAlerts[1] = $"The {type} {name} was successfully {action}";
            }
            else
            {
                tempAlerts[0] = "alert alert-warning alert-dismissible";
                tempAlerts[1] = $"The {type} {name} was not {action}";
            }
            return tempAlerts;
        }
    }
}
