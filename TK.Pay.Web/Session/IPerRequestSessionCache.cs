using System.Threading.Tasks;
using TK.Pay.Sessions.Dto;

namespace TK.Pay.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
