using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using TK.Pay.Authorization;
using TK.Pay.Web.Controllers;

namespace TK.Pay.Web.Areas.Mpa.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : PayControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}