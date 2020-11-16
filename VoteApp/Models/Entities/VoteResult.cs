using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteApp.Models.Entities
{
    public class VoteResult
    {
        public string NameOption { get; set; }
        public int CountVotes { get; set; }
    }
}
