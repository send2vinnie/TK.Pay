using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using TK.Pay.Web.Controllers;

namespace TK.Pay.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class WelcomeController : PayControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}