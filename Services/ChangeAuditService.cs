using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangeAudit.WebApi.Models.DB;
using ChangeAudit.WebApi.Models.Requests;
using ChangeAudit.WebApi.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace ChangeAudit.WebApi.Services
{
    public class ChangeAuditService : IChangeAuditService
    {
        private readonly ChangeAuditContext context;

        public ChangeAuditService(ChangeAuditContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<DeviceType>> GetDeviceTypes()
        {
            return await context.DeviceTypes.ToListAsync();
        }

        public async Task<long> InsertDataAuditAsync(DataAuditRequest dataAudit)
        {
            var newDataAudit = new DataAuditHistory
            {
                DatabaseName = dataAudit.DatabaseName,
                TableName = dataAudit.TableName,
                ColumnName = dataAudit.ColumnName,
                KeyReference = dataAudit.KeyReference,
                OldValue = dataAudit.OldValue,
                NewValue = dataAudit.NewValue,
                DeviceTypeId = context.DeviceTypes
                                    .Where(d => d.DeviceTypeCode.Equals(dataAudit.DeviceTypeCode))
                                    .Select(s => s.DeviceTypeId)
                                    .First(),
                DeviceIdentifier = dataAudit.DeviceIdentifier,
                CustomerId = dataAudit.CustomerId,
                WorkerId = dataAudit.WorkerId,
                PatientProfileId = dataAudit.PatientProfileId,
                Timestamp = dataAudit.Timestamp.Value
            };
            context.DataAuditHistories.Add(newDataAudit);
            await context.SaveChangesAsync();
            return newDataAudit.DataAuditHistoryId;
        }

        public async Task<int> GetDeviceTypeId(string deviceTypeCode)
        {
            var deviceTypeId = await context.DeviceTypes
                                    .Where(d => d.DeviceTypeCode.Equals(deviceTypeCode))
                                    .Select(s => s.DeviceTypeId)
                                    .FirstOrDefaultAsync();
            return deviceTypeId;
        }
    }
}