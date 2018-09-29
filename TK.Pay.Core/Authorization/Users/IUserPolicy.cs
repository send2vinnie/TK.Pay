using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace TK.Pay.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
