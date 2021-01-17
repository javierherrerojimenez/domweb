using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duties.API.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Duties.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DutyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Duty
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Duty/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Duty
        [Route("CreateDuty")]
        [HttpPost]
        public async Task<bool> Post([FromBody] CreateDutyCommand createDutyCommand)
        {
            return await _mediator.Send(createDutyCommand);
        }

        // PUT: api/Duty/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
