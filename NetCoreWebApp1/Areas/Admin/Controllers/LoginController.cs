using BL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NetCoreWebApp1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        UserManager userManager = new UserManager();


        public IActionResult Index()
        {
            TempData["ReturnUrl"] = HttpContext.Request.Query["ReturnUrl"]; // Hansı səhifədən çıxıbsa daxil olanda yenə o səhifə açılsın
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string password, string ReturnUrl)
        {
            try
            {
                var account = userManager.GetFirst(u => u.Email == email && u.Password == password && u.IsActive == true);
                if(account == null)
                {
                    ModelState.AddModelError("", "İsdifadəçi tapılmadı!");
                    TempData["Mesaj"] = "İsdifadəçi tapılmadı!";
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, email)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);  
                    //return RedirectToAction("Index", "Default");

                    if(string.IsNullOrWhiteSpace(ReturnUrl)) return RedirectToAction("Index", "Default");
                    else return Redirect(ReturnUrl);
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Xəta yarandı! İsdifadəçi tapılmadı!");
                TempData["Mesaj"] = "Xəta yarandı! İsdifadəçi tapılmadı!";
            }
            return View();
        }


        [Route("Admin/Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
