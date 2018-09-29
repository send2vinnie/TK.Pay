using System.Collections.Generic;
using Abp.Application.Services.Dto;
using TK.Pay.Editions.Dto;

namespace TK.Pay.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}