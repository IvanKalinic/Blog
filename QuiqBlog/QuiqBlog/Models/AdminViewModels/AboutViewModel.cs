using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace QuiqBlog.Models.AdminViewModels
{
    public class AboutViewModel
    {
        [Display(Name="Header Image")] 
        public IFormFile HeaderImage { get; set; }

        public string SubHeader { get; set; }

        public string Content { get; set; }

    }
}
