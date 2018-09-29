using Abp.Application.Services;
using TK.Pay.Dto;
using TK.Pay.Logging.Dto;

namespace TK.Pay.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
