using System.Threading.Tasks;
using Abp.Application.Services;
using TK.Pay.Configuration.Tenants.Dto;

namespace TK.Pay.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
