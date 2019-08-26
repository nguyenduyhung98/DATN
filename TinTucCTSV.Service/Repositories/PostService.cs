using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinTucCTSV.Data;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Data.Utility;

namespace TinTucCTSV.Service.Repositories
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            _context.Remove(GetById(Id));
            await _context.SaveChangesAsync();
        }

        public async Task EditPost(int Id,string newTitle, string newContent)
        {
            var post = GetById(Id);

                post.Title = newTitle;
                post.Content = newContent;
                _context.Update(post);

            await _context.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Replies).ThenInclude(r => r.User)
                .Include(p => p.Forum);
        }

        public Post GetById(int Id)
        {
            return _context.Posts.Where(p => p.Id == Id)
                .Include(p => p.User)
                .Include(p => p.Replies).ThenInclude(r =>r.User)
                .Include(p => p.Forum)
                .FirstOrDefault();
        }

        public IEnumerable<Post> GetFilteredPost(string sortOrder, string searchQuery)
        {
            var posts = from post in _context.Posts select post;

            if (!String.IsNullOrEmpty (searchQuery)) {
                posts = _context.Posts.Where (p =>p.Title.Contains (searchQuery));
            }
            switch (sortOrder) {
                case "Name_desc":
                    posts = posts.OrderByDescending (p =>p.Title);
                    break;
                case "Date":
                    posts = posts.OrderBy (p =>p.Created);
                    break;
                case "Date_desc":
                    posts = posts.OrderByDescending (p =>p.Created);
                    break;
                default:
                    posts = posts.OrderBy (p =>p.Title);
                    break;
            }
            return posts.Include(p => p.User)
                .Include(p => p.Replies).ThenInclude(r => r.User)
                .Include(p => p.Forum);
        }

        public IEnumerable<Post> GetLastesPost(int take)
        {
            return GetAll().OrderByDescending(p => p.Created).Where(p =>p.Status == true).Take(take);
        }

        public IEnumerable<Post> GetPostForumStudent()
        {
            return _context.Posts.Where( p => p.Forum.Title == "Sinh viên" && p.Status == true)
            .Include(p => p.User)
            .Include(p => p.Replies).ThenInclude(r => r.User)
            .Include(p => p.Forum);
        }

        public async Task IsStatus(int Id, bool newStatus)
        {
            var post = GetById(Id);
                post.Status = newStatus;
            _context.Update(post);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Post> SeachPost(string stringQuery)
        {
            return GetAll().Where(post => post.Title.Contains(stringQuery)
                || post.Content.Contains(stringQuery));
        }

        public IEnumerable<Post> SeachPostForum(Forum forum, string stringQuery)
        {
            return string.IsNullOrEmpty(stringQuery)
                ? forum.Posts
                : forum.Posts.Where(post => post.Title.Contains(stringQuery)
                || post.Content.Contains(stringQuery));
        }

        public async Task ViewPost(int Id)
        {
            var post = GetById(Id);
                post.NumberRead = post.NumberRead + 1;
            _context.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
