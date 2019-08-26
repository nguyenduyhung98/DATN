using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinTucCTSV.Models.Account;

namespace TinTucCTSV.Models.Home
{
    public class HomeViewModel
    {
        public int CountUsers { get; set; }
        public int CountPosts { get; set; }
        public int CountReplies { get; set; }
        public int CountForums { get; set; }

        public AccountViewModel InfoAccount { get; set; }
    }
}
