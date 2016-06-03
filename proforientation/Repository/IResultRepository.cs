using System.Collections.Generic;
using proforientation.Models;

namespace proforientation.Repository
{
    public interface IResultRepository
    {
        IEnumerable<SubProfession> GetSubProfs(string user);
    }
}
