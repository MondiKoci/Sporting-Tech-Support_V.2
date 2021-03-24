using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Please enter first name!"),
            RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter last name!"),
            RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string LastName { get; set; }

        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-z]{2,}$",
         ErrorMessage = "Incorrect email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter address!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter postal code!")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter city!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter province!")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please select a country!")]
        public int? CountryId { get; set; }
        public Country Country { get; set; }

        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}",
         ErrorMessage = "Incorrect phone format.")]
        public string Phone { get; set; }
        public string Slug => FirstName?.Replace(" ", "-").ToLower() + LastName?.Replace(" ", "-").ToLower();
    }
}
