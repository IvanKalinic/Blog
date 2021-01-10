using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuiqBlog.Data;
using QuiqBlog.Data.Models;
using QuiqBlog.Service.Interfaces;

namespace QuiqBlog.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserService(ApplicationDbContext ApplicationDbContext)
        {
            this.applicationDbContext = ApplicationDbContext;
        }

        public async Task<ApplicationUser> Update(ApplicationUser applicationUser)
        {
            applicationDbContext.Update(applicationUser);
            await applicationDbContext.SaveChangesAsync();
            return applicationUser;
        }
    }
}
