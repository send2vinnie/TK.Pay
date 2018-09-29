namespace TK.Pay.Web.MultiTenancy
{
    public interface ITenancyNameFinder
    {
        string GetCurrentTenancyNameOrNull();
    }
}