using System.Collections.Generic;
using Abp.Dependency;
using Abp.RealTime;

namespace TK.Pay.Authorization.Users
{
    public interface IUserLogoutInformer
    {
        void InformClients(IReadOnlyList<IOnlineClient> clients);
    }
}
