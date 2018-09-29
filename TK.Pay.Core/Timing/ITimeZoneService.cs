using System.Threading.Tasks;
using Abp.Configuration;

namespace TK.Pay.Timing
{
    public interface ITimeZoneService
    {
        Task<string> GetDefaultTimezoneAsync(SettingScopes scope, int? tenantId);
    }
}
