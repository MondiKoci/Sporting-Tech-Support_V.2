using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please enter a Country name.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        [StringLength(51, ErrorMessage = "Country name must be 51 characters or less.")]
        public string Name { get; set; }
        public string Slug => Name?.Replace(" ", "-").ToLower();
    }
}
