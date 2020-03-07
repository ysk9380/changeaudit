using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ChangeAudit.WebApi.Models.Requests
{
    public class DataAuditRequest
    {
        [Required]
        [Display(Name = "Database Name")]
        [StringLength(100, ErrorMessage = "{0} length cannot be more than {1}.")]
        public string DatabaseName { get; set; }
        [Required]
        [Display(Name = "Table Name")]
        [StringLength(100, ErrorMessage = "{0} length cannot be more than {1}.")]
        public string TableName { get; set; }
        [Required]
        [Display(Name = "Column Name")]
        [StringLength(100, ErrorMessage = "{0} length cannot be more than {1}.")]
        public string ColumnName { get; set; }
        [Display(Name = "Key Reference")]
        [Range(1, Int64.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public long KeyReference { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        [Required]
        [Display(Name = "Device Type Code")]
        [StringLength(100, ErrorMessage = "{0} length cannot be more than {1}.")]
        public string DeviceTypeCode { get; set; }
        public string DeviceIdentifier { get; set; }
        public long? CustomerId { get; set; }
        public long? WorkerId { get; set; }
        public long? PatientProfileId { get; set; }
        [Required]
        public DateTime? Timestamp { get; set; }
    }
}