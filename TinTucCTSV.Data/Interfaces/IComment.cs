using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Data.Interfaces
{
    public interface IComment
    {
        IEnumerable<PostReply> GetAll();
        PostReply GetById(int Id);
        int NumberCommentPost(int Id);
        Task AddReply(PostReply postReply);
        Task DeleteReply(int Id);
    }
}
