using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        [StringLength(51, ErrorMessage = "First name must be 51 characters or less.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        [StringLength(51, ErrorMessage = "Last name must be 51 characters or less.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-z]{2,}$",
         ErrorMessage = "Incorrect email format.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(51, ErrorMessage = "Email must be 51 characters or less.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a phone number!"),
            RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}",
         ErrorMessage = "Incorrect phone format.")]
        public string Phone { get; set; }

        public string Slug => FirstName?.Replace(" ", "-").ToLower() + LastName?.Replace(" ", "-").ToLower();
    }
}
