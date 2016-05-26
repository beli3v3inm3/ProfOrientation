using System.Web.Mvc;
using proforientation.Models;
using proforientation.Repository;

namespace proforientation.Controllers
{
    public class TestController : Controller
    {

        private readonly TestRepository _testRepository;

        public TestController(TestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllTest() => Json(_testRepository.GetAllQuestions(), JsonRequestBehavior.AllowGet);

        [HttpGet]
        public JsonResult GetTestById(int id) => Json(_testRepository.GetTestById(id), JsonRequestBehavior.AllowGet);

        [HttpGet]
        public JsonResult GetAnswerByTestId(int id) => Json(_testRepository.GetTestByAnswerId(id), JsonRequestBehavior.AllowGet);

        [HttpGet]
        public JsonResult GetAllProfessions() => Json(_testRepository.GetProfessions(), JsonRequestBehavior.AllowGet);
    }
}