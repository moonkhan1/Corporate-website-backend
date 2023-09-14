﻿using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApp1.Models;
using NetCoreWebApp1.Utils;
using System.Diagnostics;

namespace NetCoreWebApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // With Dependency injection
        //private readonly IRepository<Slider> _sliderService;
        //private readonly IRepository<News> _newsService;
        //private readonly IRepository<Post> _postService;
        //private readonly IRepository<Contact> _contactService;


        CategoryManager categoryManager = new CategoryManager();
        SliderManager sliderManager = new SliderManager();
        NewsManager newsManager = new NewsManager();
        PostManager postManager = new PostManager();
        ContactManager contactManager = new ContactManager();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_sliderService = sliderService;
            //_newsService = newsService;
            //_postService = postService;
            //_contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel()
            {
                Sliders =  await sliderManager.GetAllListAsync(),//sliderManager
                News = await newsManager.GetAllListAsync(),//newsManager
                Posts = await postManager.GetAllListAsync(),//postManager
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contact.CreationDate = DateTime.Now;
                    var isMailSent = MailHelper.SendMail(contact);
                    var result = await contactManager.Add(contact);
                    if (result > 0 && isMailSent)
                    {
                        TempData["Mesaj"] = "<div class='alert alert-success'>Mesaj Göndərildi!</div>";
                        return RedirectToAction("Contact");
                    }
                    else
                    {
                        TempData["Mesaj"] = "<div class='alert alert-warning'>Mesaj Göndərilə bilmədi!</div>";
                    }    
                }
                catch (Exception)
                {

                    TempData["Mesaj"] = "<div class='alert alert-danger'> Xəta yarandı! Mesaj Göndərilə bilmədi!</div>"; 
                }
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}