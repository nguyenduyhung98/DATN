using System.Threading.Tasks;
using System.Collections.Generic;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Data.Interfaces
{
    public interface IRegency
    {
        IEnumerable<Regency> GetAll();
        Regency GetById(string Id);

        Task Add(Regency regency);
        Task Edit(string Id, string newTitle);
        Task Delete(string Id);
    }
}