using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using TK.Pay.Authorization.Users;
using TK.Pay.MultiTenancy;

namespace TK.Pay.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
