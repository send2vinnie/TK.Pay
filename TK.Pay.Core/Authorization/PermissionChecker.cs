using Abp.Authorization;
using TK.Pay.Authorization.Roles;
using TK.Pay.Authorization.Users;
using TK.Pay.MultiTenancy;

namespace TK.Pay.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
