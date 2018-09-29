using System.Threading.Tasks;
using Abp.Application.Services;
using TK.Pay.Configuration.Host.Dto;

namespace TK.Pay.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
