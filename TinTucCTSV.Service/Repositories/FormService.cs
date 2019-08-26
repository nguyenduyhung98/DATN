using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinTucCTSV.Data;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Service.Repositories
{
    public class FormService : IForm
    {
        private readonly ApplicationDbContext _context;
        public FormService(ApplicationDbContext context){
            _context = context;
        }
        public async Task Add(Form form)
        {
            _context.Add(form);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? Id)
        {
            _context.Remove(GetById(Id));
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Form> GetAll()
        {
            return _context.Forms;
        }

        public Form GetById(int? Id)
        {
            return _context.Forms.Where(f => f.Id == Id).FirstOrDefault();
        }

        public async Task Update(int Id, string newLink)
        {
            var form = GetById(Id);
                form.LinkUrl = newLink;

            _context.Forms.Update(form);
            await _context.SaveChangesAsync();
        }
    }
}