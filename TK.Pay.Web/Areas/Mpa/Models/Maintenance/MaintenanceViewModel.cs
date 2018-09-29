using System.Collections.Generic;
using TK.Pay.Caching.Dto;

namespace TK.Pay.Web.Areas.Mpa.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}