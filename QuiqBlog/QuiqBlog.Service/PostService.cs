﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuiqBlog.Data;
using QuiqBlog.Data.Models;
using QuiqBlog.Service.Interfaces;

namespace QuiqBlog.Service
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public PostService(ApplicationDbContext ApplicationDbContext)
        {
            this.applicationDbContext = ApplicationDbContext;
        }

        public Post GetPost(int postId)
        {
            return applicationDbContext.Posts
                .Include(post=> post.Creator)
                .Include(post => post.Comments)
                    .ThenInclude(comment => comment.Author)
                .Include(post=>post.Comments)
                    .ThenInclude(comment => comment.Comments)
                .FirstOrDefault(post => post.Id == postId);
        }

        public IEnumerable<Post> GetPosts(string searchString)
        {
            return applicationDbContext.Posts
                .OrderByDescending(post => post.UpdatedOn)
                .Include(post => post.Creator)
                .Include(post => post.Comments)
                .Where(post => post.Title.Contains(searchString) || post.Content.Contains(searchString));
        }
        public IEnumerable<Post> GetPosts(ApplicationUser applicationUser)
        {
            return applicationDbContext.Posts
                .Include(post => post.Creator)
                .Include(post => post.Approver)
                .Include(post => post.Comments)
                .Where(post => post.Creator == applicationUser);
        }
        public async Task<Post> Add(Post post)
        {
            applicationDbContext.Add(post);
            await applicationDbContext.SaveChangesAsync();

            return post;
        }

        public async Task<Post> Update(Post post)
        {
            applicationDbContext.Update(post);
            await applicationDbContext.SaveChangesAsync();

            return post;
        }
    }
}
