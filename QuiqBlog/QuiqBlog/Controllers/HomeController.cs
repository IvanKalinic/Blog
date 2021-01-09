using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuiqBlog.Models;
using System.Diagnostics;
using QuiqBlog.BusinessManagers.Interfaces;

namespace QuiqBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostBusinessManager postBusinessManager;
        public HomeController(IPostBusinessManager postBusinessManager)
        {
            this.postBusinessManager = postBusinessManager;
        }

        public IActionResult Index(string searchString, int? page)
        {
            return View(postBusinessManager.GetIndexViewModel(searchString,page));
        }

    }
}
