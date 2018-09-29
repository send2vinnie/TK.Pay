using System.Threading.Tasks;
using Abp.Application.Services;
using TK.Pay.Sessions.Dto;

namespace TK.Pay.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
