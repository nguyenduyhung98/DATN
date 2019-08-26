using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TinTucCTSV.Data;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Service.Repositories
{
    public class RegencyService : IRegency
    {
        private readonly ApplicationDbContext _context;
        public RegencyService(ApplicationDbContext context){
            _context = context;
        }
        public async Task Add(Regency regency)
        {
            _context.Add(regency);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            _context.Remove(GetById(Id));
            await _context.SaveChangesAsync();
        }

        public async Task Edit(string Id, string newTitle)
        {
            var regency = GetById(Id);
                regency.Name = newTitle;
            _context.Update(regency);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Regency> GetAll()
        {
            return _context.Regencys;
        }

        public Regency GetById(string Id)
        {
            return _context.Regencys.Where(r => r.Id == Id)
            .Include(user => user.Users).FirstOrDefault();
        }
    }
}