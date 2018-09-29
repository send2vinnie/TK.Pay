using Abp.Notifications;
using TK.Pay.Dto;

namespace TK.Pay.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}