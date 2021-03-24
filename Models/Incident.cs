using System;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Please enter incident title!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter description!")]
        public string Description { get; set; }

        public DateTime DateOpened { get; set; } = DateTime.Now;

        public DateTime? DateClosed { get; set; }

        public int? TechnicianId { get; set; }

        public Technician Technician { get; set; }

        [Required(ErrorMessage = "Please select a customer!")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please select a product!")]
        public int? ProductId { get; set; }

        public Product Product { get; set; }
        public string Slug => Title?.Replace(" ", "-").ToLower();
    }
}
