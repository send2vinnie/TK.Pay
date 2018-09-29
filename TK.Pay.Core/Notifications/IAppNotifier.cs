using System.Threading.Tasks;
using Abp;
using Abp.Notifications;
using TK.Pay.Authorization.Users;
using TK.Pay.MultiTenancy;

namespace TK.Pay.Notifications
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        Task NewUserRegisteredAsync(User user);

        Task NewTenantRegisteredAsync(Tenant tenant);

        Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
