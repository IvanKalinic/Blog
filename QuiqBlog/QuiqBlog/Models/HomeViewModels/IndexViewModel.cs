using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Core;
using QuiqBlog.Data.Models;
using QuiqBlog.Service;

namespace QuiqBlog.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public IPagedList<Post> Posts  { get; set; }

        public string SearchString { get; set; }

        public int PageNumber { get; set; }
    }
}
