using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using TK.Pay.Authorization;
using TK.Pay.Web.Controllers;

namespace TK.Pay.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : PayControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}