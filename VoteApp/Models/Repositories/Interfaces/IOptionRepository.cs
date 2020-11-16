using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteApp.Models.Entities
{
    public interface IOptionRepository
    {
        void Create(Option user);
        void Delete(int id);
        Option Get(int id);
        List<Option> GetOptions();
        void Update(Option option);
    }
}
