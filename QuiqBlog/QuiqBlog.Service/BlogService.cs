using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuiqBlog.Data;
using QuiqBlog.Data.Models;
using QuiqBlog.Service.Interfaces;

namespace QuiqBlog.Service
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BlogService(ApplicationDbContext ApplicationDbContext)
        {
            this.applicationDbContext = ApplicationDbContext;
        }
        public async Task<Blog> Add(Blog blog)
        {
            applicationDbContext.Add(blog);
            await applicationDbContext.SaveChangesAsync();

            return blog;

        }
    }
}
