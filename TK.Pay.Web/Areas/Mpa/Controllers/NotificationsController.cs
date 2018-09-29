using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using TK.Pay.Authorization;
using TK.Pay.Notifications;
using TK.Pay.Web.Controllers;

namespace TK.Pay.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class NotificationsController : PayControllerBase
    {
        private readonly INotificationAppService _notificationApp;

        public NotificationsController(INotificationAppService notificationApp)
        {
            _notificationApp = notificationApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> SettingsModal()
        {
            var notificationSettings = await _notificationApp.GetNotificationSettings();
            return PartialView("_SettingsModal", notificationSettings);
        }
    }
}