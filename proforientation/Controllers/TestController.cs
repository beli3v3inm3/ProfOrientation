using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using proforientation.Models;
using proforientation.Repository;

namespace proforientation.Controllers
{
    public class TestController : Controller
    {

        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
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

        [HttpPost]
        public JsonResult TestResult(UsersToProf usersToProf)
        {
            var user = User.Identity.GetUserId();
            if (!ModelState.IsValid) return Json(new { Respone = "Failure" });

            var submitTest = new UsersToProf()
            {
                ProfId = usersToProf.ProfId,
                UserId = user
            };
            _testRepository.SubmitTestResult(submitTest);
            return Json(new
            {
                redirectUrl = Url.Action("Index", "Result"),
                isRedirect = true
            });
        }
    }
}