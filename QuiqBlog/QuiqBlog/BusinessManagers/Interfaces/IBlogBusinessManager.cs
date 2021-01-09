using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.BlogViewModels;

namespace QuiqBlog.BusinessManagers.Interfaces
{
    public interface IBlogBusinessManager
    {
        Task<Blog> CreateBlog(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal);

        Task<ActionResult<EditViewModel>> UpdateBlog(EditViewModel editViewModel,
            ClaimsPrincipal claimsPrincipal);

        Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);
    }
}
