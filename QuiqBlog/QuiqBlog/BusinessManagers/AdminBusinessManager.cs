using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.AdminViewModels;
using QuiqBlog.Service.Interfaces;

namespace QuiqBlog.BusinessManagers
{
    public class AdminBusinessManager : IAdminBusinessManager
    {
        private UserManager<ApplicationUser> userManager;
        private IPostService postService;

        public AdminBusinessManager(UserManager<ApplicationUser> UserManager, IPostService postService)
        {
            this.userManager = UserManager;
            this.postService = postService;
        }
        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal)
        {
            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);
            return new IndexViewModel
            {
                Posts = postService.GetPosts(applicationUser)
            };
        }
    }
}
