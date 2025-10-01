using System.Diagnostics;

namespace Surgery_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceSurgery _serviceSurgery;

        public HomeController(IServiceSurgery serviceSurgery)
        {
            _serviceSurgery = serviceSurgery;
        }
        public async Task<IActionResult> Index()
        {
            var surgeries =await _serviceSurgery.GetAllSurgeriesAsync();
            return View(surgeries);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
