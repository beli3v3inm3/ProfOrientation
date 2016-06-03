using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proforientation.Models;

namespace proforientation.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ResultRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<SubProfession> GetSubProfs(string user)
        {
            var getProfs = from data in _dbContext.UsersToProfs.Where(_ => _.UserId == user)
                            from prof in _dbContext.SubProfessions.Where(_ => _.ProfId == data.ProfId)
                            select prof;

            foreach (var profession in getProfs)
            {
                yield return profession;
            }
        }
    }
}