using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }

        [Required(ErrorMessage = "Please select a customer.")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

      
    }
}
