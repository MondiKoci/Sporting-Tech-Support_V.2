using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class RegistrationListViewModel
    {
        public List<Registration> Registrations { get; set; }
        public List<Customer> Customers { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        public List<SelectListItem> ProductList { get; set; }
        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }
 
    }
}
