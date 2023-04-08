using Microsoft.AspNetCore.Mvc;
using MockAssessment5.Models;
using System.Diagnostics;

namespace MockAssessment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

/*        public IActionResult Result(Person)
        {
            return View();
        }
*/        
        [HttpPost]
        public IActionResult Result(Person person)
        {
            if (!ModelState.IsValid)    // very handy tool
            {
                return RedirectToAction("Index");
            }
            // We can process the UserProfile object now!
            // For example, we can save it to a database.

            if (person.Age >= 21) {
                person.CanDrink = true;
            }
            else person.CanDrink = false;

            if (person.Age >= 16) { 
                person.CanDrive = true;
            }
            else person.CanDrive = false;

            return View("Result", person);
        }

       
        public IActionResult GetAge(Person person)
        {
            
            return View(person);
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}