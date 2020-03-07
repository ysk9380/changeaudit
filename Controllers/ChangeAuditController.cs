using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangeAudit.WebApi.Models.Requests;
using ChangeAudit.WebApi.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace ChangeAudit.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChangeAuditController : ControllerBase
    {
        private readonly IChangeAuditService changeAuditService;

        public ChangeAuditController(IChangeAuditService changeAuditService)
        {
            this.changeAuditService = changeAuditService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var deviceTypes = await changeAuditService.GetDeviceTypes();
            return Ok(deviceTypes);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(DataAuditRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else if (request.OldValue == request.NewValue)
                return BadRequest("There was not change in the data. This request cannot be audited.");
            else if ((await changeAuditService.GetDeviceTypeId(request.DeviceTypeCode)) == 0)
                return BadRequest("Invalid Device Type Code.");
            else
                await changeAuditService.InsertDataAuditAsync(request);

            return Accepted();
        }
    }
}