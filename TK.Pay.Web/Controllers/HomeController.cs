using System.Web.Mvc;

namespace TK.Pay.Web.Controllers
{
    public class HomeController : PayControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}