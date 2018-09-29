using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TK.Pay.Authorization.Users.Dto;

namespace TK.Pay.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
