using GBCSporting2021_TheDevelopers.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_TheDevelopers.Controllers
{
    public class HomeController : Controller
    {

        private SportContext context { get; set; }

        public HomeController(SportContext scx)
        {
            context = scx;
        }

        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }





    }
}
