using System.Web.Mvc;
using proforientation.Models;
using proforientation.Repository;
using Microsoft.AspNet.Identity;

namespace proforientation.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultRepository _resultRepository;

        public ResultController(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetSubProfessions()
        {
            var user = User.Identity.GetUserId();
            return Json(_resultRepository.GetSubProfs(user), JsonRequestBehavior.AllowGet);
        }
    }
}