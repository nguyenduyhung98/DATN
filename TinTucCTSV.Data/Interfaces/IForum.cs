using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Data.Interfaces
{
    public interface IForum
    {
        Forum GetById(int Id);

        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetActiveUsers();

        Task Create(Forum forum);

        Task Delete(int Id);

        Task UpdateForum(int Id, string newTitle, string newDescription,string newImageUrl);

        IEnumerable<Forum> listForumKeyValue();
    }
}
