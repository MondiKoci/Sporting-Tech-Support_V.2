using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }


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
        [Remote("CheckEmail", "Validation")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter address.")]
        [StringLength(51, ErrorMessage = "Address must be 51 characters or less.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter postal code.")]
        [StringLength(21, ErrorMessage = "Postal code must be 21 characters or less.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter city!")]
        [StringLength(51, ErrorMessage = "City name must be 51 characters or less.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter province!")]
        [StringLength(51, ErrorMessage = "Province must be 51 characters or less.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please select a country!")]
        [Remote("CheckCountry", "Validation")]
        public int? CountryId { get; set; }
        public Country Country { get; set; }

        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}",
         ErrorMessage = "Incorrect phone format.")]
        public string Phone { get; set; }
        public string Slug => FirstName?.Replace(" ", "-").ToLower() + LastName?.Replace(" ", "-").ToLower();
    }
}
