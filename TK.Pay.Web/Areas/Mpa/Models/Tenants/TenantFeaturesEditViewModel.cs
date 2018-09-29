using Abp.AutoMapper;
using TK.Pay.MultiTenancy;
using TK.Pay.MultiTenancy.Dto;
using TK.Pay.Web.Areas.Mpa.Models.Common;

namespace TK.Pay.Web.Areas.Mpa.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesForEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesForEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesForEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}