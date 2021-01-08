using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QuiqBlog.Data.Models;

namespace QuiqBlog.Models.BlogViewModels
{
    public class CreateViewModel
    {
        [Required,Display(Name = "Header Image")] 
        public IFormFile BlogHeaderImage { get; set; }
        
        public Blog Blog { get; set; }

    }
}
