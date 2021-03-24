namespace GBCSporting2021_TheDevelopers.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Slug => Name?.Replace(" ", "-").ToLower();
    }
}
