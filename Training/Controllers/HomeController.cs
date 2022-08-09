using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Training.Models;

namespace Training.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Countries = new List<string>
            {
                "india",
                "egypt"
            };

            return View();
        }
    }
}