using System.Web.Mvc;

namespace TK.Pay.Web.Controllers
{
    public class AboutController : PayControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}