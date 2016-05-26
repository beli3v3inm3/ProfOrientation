using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proforientation.Models;

namespace proforientation.Repository
{
    public interface IProfessionRepository
    {
        IEnumerable<Profession> GetProfessions();
        IEnumerable<Profession> GetProfessionById(int id);
    }
}
