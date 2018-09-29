namespace TK.Pay.Web.Areas.Mpa.Models.OrganizationUnits
{
    public class CreateOrganizationUnitModalViewModel
    {
        public long? ParentId { get; set; }
        
        public CreateOrganizationUnitModalViewModel(long? parentId)
        {
            ParentId = parentId;
        }
    }
}