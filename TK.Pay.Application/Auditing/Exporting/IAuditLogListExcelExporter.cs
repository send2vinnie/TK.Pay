using System.Collections.Generic;
using TK.Pay.Auditing.Dto;
using TK.Pay.Dto;

namespace TK.Pay.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
