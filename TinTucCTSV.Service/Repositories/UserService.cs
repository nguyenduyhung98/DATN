using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinTucCTSV.Data;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Service.Repositories
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context){
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers
            .Include(r => r.Regency)
            .Include(p => p.Posts);
        }

        public ApplicationUser GetById(string Id)
        {
            return _context.ApplicationUsers.Where(u => u.Id == Id)
            .Include(r => r.Regency)
            .Include(p => p.Posts).FirstOrDefault();
        }
    }
}
