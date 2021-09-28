using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CakeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICakeRepository _cakeRepository;

        // get an icakerepository as in input to constructor 
        public HomeController(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }

        // returns index page in Views and waits for func to get cake of the week
        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel
            {
                CakeOfTheWeek = await _cakeRepository.GetCakesOfTheWeek()
            });
        }
    }
}