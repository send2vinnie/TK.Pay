using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.MultiTenancy;
using Abp.Web.Mvc.Authorization;
using TK.Pay.Authorization;
using TK.Pay.Web.Controllers;

namespace TK.Pay.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PayControllerBase
    {
        public async Task<ActionResult> Index()
        {
            if (AbpSession.MultiTenancySide == MultiTenancySides.Host)
            {
                if (await IsGrantedAsync(AppPermissions.Pages_Tenants))
                {
                    return RedirectToAction("Index", "Tenants");
                }
            }
            else
            {
                if (await IsGrantedAsync(AppPermissions.Pages_Tenant_Dashboard))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            //Default page if no permission to the pages above
            return RedirectToAction("Index", "Welcome");
        }
    }
}