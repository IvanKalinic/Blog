using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuiqBlog.Data.Models;

namespace QuiqBlog.Service.Interfaces
{
    public interface IPostService
    {
        Post GetPost(int postId);
        IEnumerable<Post> GetPosts(string searchString);
        IEnumerable<Post> GetPosts(ApplicationUser applicationUser);
        Task<Post> Add(Post post);
        Task<Post> Update(Post post);


    }
}
