using System.Collections.Generic;
using System.Linq;

namespace TinTucCTSV.Models.Account
{
    public class AccountIndexModel
    {
        public IQueryable<AccountViewModel> Accounts { get; set; }
    }
}
