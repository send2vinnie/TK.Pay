using Abp.AutoMapper;
using TK.Pay.Authorization.Users;
using TK.Pay.Authorization.Users.Dto;
using TK.Pay.Web.Areas.Mpa.Models.Common;

namespace TK.Pay.Web.Areas.Mpa.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}