using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Models.BlogViewModels;

namespace QuiqBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogBusinessManager blogBusinessManager;

        public BlogController(IBlogBusinessManager BlogBusinessManager)
        {
            this.blogBusinessManager = BlogBusinessManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var actionResult = await blogBusinessManager.GetEditViewModel(id, User);
            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateViewModel createViewModel)
        {
            await blogBusinessManager.CreateBlog(createViewModel, User);
            return RedirectToAction("Create");
        }
    }
}
