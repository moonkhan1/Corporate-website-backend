using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApp1.Controllers
{
    public class PostsController : Controller
    {
        PostManager postManager = new PostManager();

        //DI ile servis kullanım
        //private readonly IRepository<Post> _postService;

        public PostsController()
        {
            //_postService = postService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();

            }
            else
            {
                var post = await postManager.GetAllList(x => x.CategoryId == id);
                return View(post);
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            var foundPost = await postManager.Find(id);
            return View(foundPost);
        }
    }
}
