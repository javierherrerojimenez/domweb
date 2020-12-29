using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Leaves.API.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leaves.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("CreateLeave")]
        [HttpPost]
        public async Task<bool> CreateLeave([FromBody] CreateLeaveCommand createLeaveCommand)
        {
            //_logger.LogInformation(
            //    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
            //    createOrderDraftCommand.GetGenericTypeName(),
            //    nameof(createOrderDraftCommand.BuyerId),
            //    createOrderDraftCommand.BuyerId,
            //    createOrderDraftCommand);

            return await _mediator.Send(createLeaveCommand);
        }

        [Route("AcceptLeave")]
        [HttpPost]
        public async Task<bool> AcceptLeave([FromBody] AcceptLeaveCommand acceptLeaveCommand)
        {
            //_logger.LogInformation(
            //    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
            //    createOrderDraftCommand.GetGenericTypeName(),
            //    nameof(createOrderDraftCommand.BuyerId),
            //    createOrderDraftCommand.BuyerId,
            //    createOrderDraftCommand);

            return await _mediator.Send(acceptLeaveCommand);
        }

        [Route("GetCreateCommandSample")]
        [HttpGet]
        public CreateLeaveCommand GetCreateCommandSample()
        {
            List<LeaveReasonDTO> reasons = new List<LeaveReasonDTO>();
            LeaveReasonDTO reason = new LeaveReasonDTO();
            reason.Name = "Nombre Razon 1";
            reason.Description = "Descripción Razon 1";

            CreateLeaveCommand c = new CreateLeaveCommand("roster1", 1, 1, reason, DateTime.Now.Date, DateTime.Now.Date, "mi comentario");
            return c;
        }

        // GET: api/Leave
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        // GET: api/Leave/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Leave
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        /*
        // PUT: api/Leave/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
