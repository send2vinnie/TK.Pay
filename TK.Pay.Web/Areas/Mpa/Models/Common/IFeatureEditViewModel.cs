using System.Collections.Generic;
using Abp.Application.Services.Dto;
using TK.Pay.Editions.Dto;

namespace TK.Pay.Web.Areas.Mpa.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}