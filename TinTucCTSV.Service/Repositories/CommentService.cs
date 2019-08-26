using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinTucCTSV.Data;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Service.Repositories
{
    public class CommentService : IComment
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddReply(PostReply postReply)
        {
            _context.Add(postReply);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReply(int Id)
        {
            _context.Remove(GetById(Id));
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PostReply> GetAll()
        {
            return _context.PostReplies
                .Include(u =>u.User)
                .Include(p =>p.Post);
        }

        public PostReply GetById(int Id)
        {
            return _context.PostReplies.Where(reply => reply.Id == Id)
                .Include(r => r.User)
                .Include(p => p.Post).FirstOrDefault();
        }

        public int NumberCommentPost(int Id)
        {
            return  (from p in _context.Posts
                    join r in _context.PostReplies on p.Id equals r.Post.Id
                    where p.Id == Id
                    group r by r.Post.Id into replyCount
                    //orderby 
                    select new
                    {
                        Id = replyCount.Key,
                        NumberReplies = replyCount.Count()
                    })
                    .SingleOrDefault().NumberReplies;
        }
    }
}
