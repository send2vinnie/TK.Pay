using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;

namespace TK.Pay.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// Add your methods to this class common for all controllers.
    /// </summary>
    public abstract class PayControllerBase : AbpController
    {
        protected PayControllerBase()
        {
            LocalizationSourceName = PayConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}