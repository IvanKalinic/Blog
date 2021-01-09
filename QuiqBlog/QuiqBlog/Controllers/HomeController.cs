﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuiqBlog.Models;
using System.Diagnostics;
using QuiqBlog.BusinessManagers.Interfaces;

namespace QuiqBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogBusinessManager blogBusinessManager;
        public HomeController(IBlogBusinessManager blogBusinessManager)
        {
            this.blogBusinessManager = blogBusinessManager;
        }

        public IActionResult Index(string searchString, int? page)
        {
            return View(blogBusinessManager.GetIndexViewModel(searchString,page));
        }

    }
}
