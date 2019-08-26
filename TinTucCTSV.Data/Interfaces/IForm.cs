using System.Collections.Generic;
using System.Threading.Tasks;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Data.Interfaces
{
    public interface IForm
    {
      IEnumerable<Form> GetAll();

      Form GetById(int? Id);

      Task Add(Form form);
      Task Delete(int? Id);
      Task Update(int Id, string newLink);
    }
}