using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using proforientation.Models;
using proforientation.Repository;

namespace proforientation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IBucketRepository _bucketRepository;

        public HomeController(IProfessionRepository professionRepository, IBucketRepository bucketRepository)
        {
            _professionRepository = professionRepository;
            _bucketRepository = bucketRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }

        [HttpGet]
        public JsonResult GetAllProfessions() => Json(_professionRepository.GetProfessions(), JsonRequestBehavior.AllowGet);

        [HttpGet]
        public JsonResult GetDetailsByProfessionId(int id)
            => Json(_professionRepository.GetProfessionById(id), JsonRequestBehavior.AllowGet);

        [HttpPost]
        public JsonResult AddToBucket(Bucket bucket)
        {
            var user = User.Identity.GetUserId();
            if (!ModelState.IsValid) return Json(new {Respone = "Failure"});

            var order = new Bucket()
            {
                ProfId = bucket.ProfId,
                UserId = user
            };
            _bucketRepository.AddToBucket(order);
            return Json(new {Response = "Success"});
        }
    }
}