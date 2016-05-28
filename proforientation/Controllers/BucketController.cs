using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using proforientation.Models;
using proforientation.Repository;

namespace proforientation.Controllers
{
    public class BucketController : Controller
    {
        private readonly BucketRepository _bucketRepository;

        public BucketController(BucketRepository bucketRepository)
        {
            _bucketRepository = bucketRepository;
        }

        // GET: Bucket
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllOrders()
        {
            var user = User.Identity.GetUserId();
            return Json(_bucketRepository.GettAllOrders(user), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CleatOrders(Bucket bucket)
        {
            var user = User.Identity.GetUserId();

            _bucketRepository.ClearOrders(user);
            return Json(new { Response = "Success" });
        }
    }
}