using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApp1.Controllers
{
    public class NewsController : Controller
    {
        //DI ile servis isdifadesi
        private readonly IRepository<News> _newsService;

        public NewsController(IRepository<News> newsService)
        {
            _newsService = newsService;
        }
        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetAllListAsync();
            return View(news);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundNews = await _newsService.Find(id);

            if (foundNews == null)
            {
                return NotFound();
            }

            return View(foundNews);
        }
    }
}
