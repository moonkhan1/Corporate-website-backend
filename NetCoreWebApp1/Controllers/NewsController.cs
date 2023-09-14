using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApp1.Controllers
{
    public class NewsController : Controller
    {
        NewsManager newsManager = new NewsManager();

        //private readonly IRepository<News> _newsService;

        public NewsController()
        {
            //_newsService = newsService;
        }
        public async Task<IActionResult> Index()
        {
            var news = await newsManager.GetAllListAsync();
            return View(news);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundNews = await newsManager.Find(id);

            if (foundNews == null)
            {
                return NotFound();
            }

            return View(foundNews);
        }
    }
}
