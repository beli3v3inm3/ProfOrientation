using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proforientation.Models;

namespace proforientation.Repository
{
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfessionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Profession> GetProfessions() => _dbContext.Professions;

        public IEnumerable<Profession> GetProfessionById(int id)
        {
            yield return _dbContext.Professions.FirstOrDefault(_ => _.Id == id);
        }
    }
}