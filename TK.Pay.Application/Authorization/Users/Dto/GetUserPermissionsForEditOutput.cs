﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using TK.Pay.Authorization.Permissions.Dto;

namespace TK.Pay.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}