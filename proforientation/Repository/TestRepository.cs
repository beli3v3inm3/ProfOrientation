using System.Collections.Generic;
using System.Linq;
using proforientation.Models;

namespace proforientation.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TestRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Test> GetAllQuestions() => _dbContext.Tests;

        public IEnumerable<Answer> GetTestByAnswerId(int id)
        {
            var getTestId = (from item in _dbContext.Tests
                             where item.Id == id
                             select item).FirstOrDefault();

            var getAnswrs = from item in _dbContext.Answers
                           where item.TestId == getTestId.Id
                           select item;

            foreach (var answer in getAnswrs)
                yield return answer;
        }

        public IEnumerable<Test> GetTestById(int id)
        {
            yield return _dbContext.Tests.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Profession> GetProfessions() => _dbContext.Professions;
    }
}
