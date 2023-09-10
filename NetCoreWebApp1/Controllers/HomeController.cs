using BL;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApp1.Models;
using System.Diagnostics;

namespace NetCoreWebApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        CategoryManager categoryManager = new CategoryManager();
        SliderManager sliderManager = new SliderManager();
        NewsManager newsManager = new NewsManager();
        PostManager postManager = new PostManager();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel()
            {
                Categories = await categoryManager.GetAllList(),
                Sliders = await sliderManager.GetAllList(),
                News = await newsManager.GetAllList(),
                Posts = await postManager.GetAllList()
            };
            return View();
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