using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using TK.Pay.Web.Areas.Mpa.Models.Common.Modals;
using TK.Pay.Web.Controllers;

namespace TK.Pay.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class CommonController : PayControllerBase
    {
        public PartialViewResult LookupModal(LookupModalViewModel model)
        {
            return PartialView("Modals/_LookupModal", model);
        }
    }
}