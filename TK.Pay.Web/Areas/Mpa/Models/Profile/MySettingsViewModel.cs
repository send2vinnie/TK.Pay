using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using TK.Pay.Authorization.Users;
using TK.Pay.Authorization.Users.Profile.Dto;

namespace TK.Pay.Web.Areas.Mpa.Models.Profile
{
    [AutoMapFrom(typeof (CurrentUserProfileEditDto))]
    public class MySettingsViewModel : CurrentUserProfileEditDto
    {
        public List<ComboboxItemDto> TimezoneItems { get; set; }

        public bool CanChangeUserName
        {
            get { return UserName != User.AdminUserName; }
        }

        public MySettingsViewModel(CurrentUserProfileEditDto currentUserProfileEditDto)
        {
            currentUserProfileEditDto.MapTo(this);
        }
    }
}