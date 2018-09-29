using Abp.Application.Services;
using TK.Pay.Tenants.Dashboard.Dto;

namespace TK.Pay.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
