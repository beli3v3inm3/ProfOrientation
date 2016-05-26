using System.Collections.Generic;
using proforientation.Models;

namespace proforientation.Repository
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetAllQuestions();
        IEnumerable<Answer> GetTestByAnswerId(int id);
        IEnumerable<Test> GetTestById(int id);
        IEnumerable<Profession> GetProfessions();
    }
}
