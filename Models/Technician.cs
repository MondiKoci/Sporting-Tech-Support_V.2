using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter first name!"),
            RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name!"),
            RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an email!"),
            RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$",
         ErrorMessage = "Incorrect email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a phone number!"),
            RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}",
         ErrorMessage = "Incorrect phone format.")]
        public string Phone { get; set; }

        public string Slug => FirstName?.Replace(" ", "-").ToLower() + LastName?.Replace(" ", "-").ToLower();
    }
}
