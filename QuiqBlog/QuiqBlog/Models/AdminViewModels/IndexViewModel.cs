using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuiqBlog.Data.Models;

namespace QuiqBlog.Models.AdminViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; }

    }
}
