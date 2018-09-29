using Abp.Domain.Services;

namespace TK.Pay
{
    public abstract class PayDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected PayDomainServiceBase()
        {
            LocalizationSourceName = PayConsts.LocalizationSourceName;
        }
    }
}
