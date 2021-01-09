using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuiqBlog.Authorization;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.BlogViewModels;
using QuiqBlog.Service.Interfaces;

namespace QuiqBlog.BusinessManagers
{
    public class BlogBusinessManager : IBlogBusinessManager
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly IBlogService blogService;

        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IAuthorizationService authorizationService;

        public BlogBusinessManager(UserManager<ApplicationUser> UserManager, IBlogService BlogService,IWebHostEnvironment webHostEnvironment, IAuthorizationService authorizationService)
        {
            this.userManager = UserManager;
            this.blogService = BlogService;
            this.webHostEnvironment = webHostEnvironment;
            this.authorizationService = authorizationService;
        }
        public async Task<Blog> CreateBlog(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal)
        {
            Blog blog = createViewModel.Blog;

            blog.Creator = await userManager.GetUserAsync(claimsPrincipal);
            blog.CreatedOn = DateTime.Now;
            blog.UpdatedOn = DateTime.Now;

            blog = await blogService.Add(blog);

            string webRootPath = webHostEnvironment.WebRootPath;
            string pathToImage = $@"{webRootPath}\UserFiles\Blogs\{blog.Id}\HeaderImage.jpg";

            EnsureFolder(pathToImage);

            using (var fileStream = new FileStream(pathToImage, FileMode.Create))
            {
                await createViewModel.BlogHeaderImage.CopyToAsync(fileStream);
            }

            return blog;
        }

        public async Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal)
        {
            if (id is null)
                return new BadRequestResult();
            
            var blogId = id.Value;
            var blog = blogService.GetBlog(blogId);

            if (blog is null)
                return new NotFoundResult();

            var authorizationResult =
                await authorizationService.AuthorizeAsync(claimsPrincipal, blog, Operations.Update);
            if (!authorizationResult.Succeeded)
            {
                if(claimsPrincipal.Identity.IsAuthenticated)
                    return new ForbidResult();
                else 
                    return new ChallengeResult();
            }

            return new EditViewModel
            {
                Blog = blog
            };
        }

        private void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}
