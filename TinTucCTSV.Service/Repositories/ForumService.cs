using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinTucCTSV.Data;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TinTucCTSV.Service.Repositories
{
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _context;
        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Forum forum)
        {
            _context.Add(forum);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            _context.Remove(GetById(Id));
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ApplicationUser> GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.Include(f => f.Posts);
        }

        public Forum GetById(int Id)
        {
            return _context.Forums.Where(f => f.Id == Id)
                .Include(f => f.Posts).ThenInclude(p => p.User)
                .Include(f => f.Posts).ThenInclude(p => p.Replies).ThenInclude(r => r.User)
                .FirstOrDefault();
        }

        public IEnumerable<Forum> listForumKeyValue()
        {
            return _context.Forums;
        }

        public async Task UpdateForum(int Id, string newTitle, string newDescription, string newImageUrl)
        {
            var forum =  GetById(Id);
            forum.Title = newTitle;
            forum.Description = newDescription;
            forum.ImageUrl = newImageUrl;
            _context.Update(forum);
            await _context.SaveChangesAsync();
        }
    }
}
