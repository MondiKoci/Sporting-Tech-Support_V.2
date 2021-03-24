using System;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter product code!")]

        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter a product name!")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a price!")]
        [Range(1.00, 100000.00, ErrorMessage = "Enter price between $1.00 and $10,000 ")]
        public double Price { get; set; } = 0.00;
        [Required(ErrorMessage = "Please enter release date!")]
        public DateTime ReleaseDate { get; set; } = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

        public string Slug =>
            Name?.Replace(' ', '-').ToLower();
    }
}
