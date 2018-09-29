using System.Collections.Generic;
using TK.Pay.Authorization.Users.Dto;

namespace TK.Pay.Web.Areas.Mpa.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}