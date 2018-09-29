using System.Web.Mvc;
using Abp.Auditing;

namespace TK.Pay.Web.Controllers
{
    public class ErrorController : PayControllerBase
    {
        [DisableAuditing]
        public ActionResult E404()
        {
            return View();
        }
    }
}