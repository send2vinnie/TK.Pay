using Abp.Dependency;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Views;

namespace TK.Pay.Web.Views
{
    public abstract class PayWebViewPageBase : PayWebViewPageBase<dynamic>
    {
       
    }

    public abstract class PayWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        public IAbpSession AbpSession { get; private set; }
        
        protected PayWebViewPageBase()
        {
            AbpSession = IocManager.Instance.Resolve<IAbpSession>();
            LocalizationSourceName = PayConsts.LocalizationSourceName;
        }
    }
}