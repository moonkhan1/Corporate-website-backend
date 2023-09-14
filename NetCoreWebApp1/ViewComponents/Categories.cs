using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApp1.ViewComponents
{
    public class Categories : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BL.CategoryManager categoryManager = new BL.CategoryManager(); 
            return View(categoryManager.GetAll());
        }
    }
}
