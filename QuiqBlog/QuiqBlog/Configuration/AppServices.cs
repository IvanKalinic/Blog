﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using QuiqBlog.Authorization;
using QuiqBlog.BusinessManagers;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data;
using QuiqBlog.Data.Models;
using QuiqBlog.Service;
using QuiqBlog.Service.Interfaces;

namespace QuiqBlog.Configuration
{
    public static class AppServices
    {
        public static void AddDefaultServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            serviceCollection.AddControllersWithViews().AddRazorRuntimeCompilation();
            serviceCollection.AddRazorPages();

            serviceCollection.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
        }

        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPostBusinessManager, PostBusinessManager>();
            serviceCollection.AddScoped<IAdminBusinessManager, AdminBusinessManager>();


            serviceCollection.AddScoped<IPostService, PostService>();
            serviceCollection.AddScoped<IUserService, UserService>();
        }

        public static void AddCustomAuthorization(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAuthorizationHandler, PostAuthorizationHandler>();
        }
    }
}
