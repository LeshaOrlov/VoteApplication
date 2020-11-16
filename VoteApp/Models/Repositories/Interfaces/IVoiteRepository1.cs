using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteApp.Models.Entities
{
    public interface IVoteRepository
    {
        void Create(Vote user);
        void Delete(int id);
        Vote Get(int id);
        List<Vote> GetVote();
        void Update(Vote user);

        List<VoteResult> GetVoteResult();
    }
}
