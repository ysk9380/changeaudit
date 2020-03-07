using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ChangeAudit.WebApi.Models.DB
{
    [Table("DeviceType")]
    public class DeviceType
    {
        public int DeviceTypeId { get; set; }
        public string DeviceTypeCode { get; set; }
        public string DeviceTypeName { get; set; }
    }

    [Table("DataAuditHistory")]
    public class DataAuditHistory
    {
        public long DataAuditHistoryId { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public long KeyReference { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceIdentifier { get; set; }
        public long? CustomerId { get; set; }
        public long? WorkerId { get; set; }
        public long? PatientProfileId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class ChangeAuditContext : DbContext
    {
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<DataAuditHistory> DataAuditHistories { get; set; }

        public ChangeAuditContext(DbContextOptions<ChangeAuditContext> options)
            : base(options)
        {

        }
    }
}