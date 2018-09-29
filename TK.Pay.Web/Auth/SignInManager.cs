using Abp.Authorization;
using Abp.Configuration;
using Abp.Domain.Uow;
using Microsoft.Owin.Security;
using TK.Pay.Authorization.Roles;
using TK.Pay.Authorization.Users;
using TK.Pay.MultiTenancy;

namespace TK.Pay.Web.Auth
{
    public class SignInManager : AbpSignInManager<Tenant, Role, User>
    {
        public SignInManager(
            UserManager userManager, 
            IAuthenticationManager authenticationManager, 
            ISettingManager settingManager,
            IUnitOfWorkManager unitOfWorkManager) 
            : base(
                  userManager, 
                  authenticationManager,
                  settingManager,
                  unitOfWorkManager)
        {
        }
    }
}