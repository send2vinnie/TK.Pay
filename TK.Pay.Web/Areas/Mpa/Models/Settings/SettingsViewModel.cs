using System.Collections.Generic;
using Abp.Application.Services.Dto;
using TK.Pay.Configuration.Tenants.Dto;

namespace TK.Pay.Web.Areas.Mpa.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}