using System.Collections.Generic;
using TK.Pay.Authorization.Users.Dto;
using TK.Pay.Dto;

namespace TK.Pay.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}