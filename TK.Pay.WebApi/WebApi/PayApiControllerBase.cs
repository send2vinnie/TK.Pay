using Abp.WebApi.Controllers;

namespace TK.Pay.WebApi
{
    public abstract class PayApiControllerBase : AbpApiController
    {
        protected PayApiControllerBase()
        {
            LocalizationSourceName = PayConsts.LocalizationSourceName;
        }
    }
}