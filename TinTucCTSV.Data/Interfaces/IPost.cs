using System.Collections.Generic;
using System.Threading.Tasks;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Data.Interfaces
{
    public interface IPost
    {
        Post GetById(int Id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPost(string sortOrder, string searchQuery);

        //Searching
        IEnumerable<Post> SeachPost(string stringQuery);
        IEnumerable<Post> SeachPostForum(Forum forum, string stringQuery);

        IEnumerable<Post> GetLastesPost(int take);

        IEnumerable<Post> GetPostForumStudent();

        Task Add(Post post);
        Task Delete(int Id);
        Task EditPost(int Id,string newTitle, string newContent);

        Task ViewPost(int Id);
        Task IsStatus(int Id, bool newStatus);
    }
}
