using Microsoft.AspNetCore.Mvc;
using TrainSchedule.Data;
using TrainSchedule.Models;
using Microsoft.AspNetCore.Authorization; // For Authorization

namespace TrainSchedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrainScheduleDbContext _context;

        public HomeController(TrainScheduleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        // ... (About and Contact actions remain the same)
        
        [HttpPost]
        public IActionResult TrainSearch(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return PartialView("_TrainSearchResults", new List<Train>());
            }

            var trains = _context.Trains
                .Where(t =>
                    t.DepartureCity.ToLower().Contains(searchTerm.ToLower()) ||
                    t.ArrivalCity.ToLower().Contains(searchTerm.ToLower())
                )
                .ToList();

            return PartialView("_TrainSearchResults", trains);
        }
        
        [HttpGet]
        public IActionResult GetCities(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return Json(new List<object>()); // Return empty list if term is null or empty
            }

            var suggestions = _context.Trains
                .Where(t => t.DepartureCity.ToLower().Contains(term.ToLower()) || t.ArrivalCity.ToLower().Contains(term.ToLower()))
                .Select(t => new 
                { 
                    value = t.DepartureCity == term ? t.DepartureCity : t.ArrivalCity, // Prioritize matching city
                    label = $"{t.DepartureCity} - {t.ArrivalCity}",  // Combine both cities
                    category = t.DepartureCity == term ? "Departure" : "Arrival" // Assign correct category
                })
                .Distinct()
                .ToList();

            return Json(suggestions);
        }
    }
}