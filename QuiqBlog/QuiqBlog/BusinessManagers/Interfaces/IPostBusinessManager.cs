using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.HomeViewModels;
using QuiqBlog.Models.PostViewModels;

namespace QuiqBlog.BusinessManagers.Interfaces
{
    public interface IPostBusinessManager
    {
        IndexViewModel GetIndexViewModel(string searchString, int? page);

        Task<ActionResult<PostViewModel>> GetPostViewModel(int? id, ClaimsPrincipal claimsPrincipal);
        Task<Post> CreatePost(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal);

        Task<ActionResult<EditViewModel>> UpdatePost(EditViewModel editViewModel,
            ClaimsPrincipal claimsPrincipal);

        Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);
    }
}
