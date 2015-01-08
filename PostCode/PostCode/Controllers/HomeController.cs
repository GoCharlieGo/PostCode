using System.Web.Mvc;

namespace PostCode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public string GetInfo()
        //{
        //    var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //    var email = HttpContext.User.Identity.Name;
        //    var gender = identity.Claims.Where(c => c.Type == ClaimTypes.Gender).Select(c => c.Value).SingleOrDefault();
        //    var age = identity.Claims.Where(c => c.Type == "age").Select(c => c.Value).SingleOrDefault();
        //    return "<p>Эл. адрес: " + email + "</p><p>Пол:" + gender + "</p><p> Возраст:" + age + "</p>";
        //}
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}