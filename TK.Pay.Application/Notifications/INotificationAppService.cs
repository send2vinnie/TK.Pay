using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TK.Pay.Notifications.Dto;

namespace TK.Pay.Notifications
{
    public interface INotificationAppService : IApplicationService
    {
        Task<GetNotificationsOutput> GetUserNotifications(GetUserNotificationsInput input);

        Task SetAllNotificationsAsRead();

        Task SetNotificationAsRead(EntityDto<Guid> input);

        Task<GetNotificationSettingsOutput> GetNotificationSettings();
        
        Task UpdateNotificationSettings(UpdateNotificationSettingsInput input);
    }
}