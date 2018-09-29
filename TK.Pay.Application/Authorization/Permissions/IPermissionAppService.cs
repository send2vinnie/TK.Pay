using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TK.Pay.Authorization.Permissions.Dto;

namespace TK.Pay.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
