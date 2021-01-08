using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuiqBlog.Data.Models;

namespace QuiqBlog.Service.Interfaces
{
    public interface IBlogService
    {
       Task<Blog> Add(Blog blog);
    }
}
