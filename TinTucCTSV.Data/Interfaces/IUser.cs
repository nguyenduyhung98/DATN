using System;
using System.Collections.Generic;
using System.Text;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Data.Interfaces
{
    public interface IUser
    {
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetById(string Id);        
    }
}
