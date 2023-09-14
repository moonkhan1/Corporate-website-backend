using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApp1.Controllers
{
    public class PostsController : Controller
    {

        //DI ile servis isdifadesi
        private readonly IRepository<Post> _postService;

        public PostsController(IRepository<Post> postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();

            }
            else
            {
                var post = await _postService.GetAllList(x => x.CategoryId == id);
                return View(post);
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            var foundPost = await _postService.Find(id);
            return View(foundPost);
        }
    }
}
