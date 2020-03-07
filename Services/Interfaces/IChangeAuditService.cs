using System.Collections.Generic;
using System.Threading.Tasks;
using ChangeAudit.WebApi.Models.DB;
using ChangeAudit.WebApi.Models.Requests;

namespace ChangeAudit.WebApi.Services.Intefaces
{
    public interface IChangeAuditService
    {
        Task<IEnumerable<DeviceType>> GetDeviceTypes();
        Task<long> InsertDataAuditAsync(DataAuditRequest dataAudit);
        Task<int> GetDeviceTypeId(string deviceTypeCode);
    }
}