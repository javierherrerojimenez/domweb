using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duties.API.Commands;
using Duties.API.Queries;
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
        private readonly IDutiesQueries _dutiesQueries;

        public DutyController(IMediator mediator, IDutiesQueries dutiesQueries)
        {
            _mediator = mediator;
            _dutiesQueries = dutiesQueries;
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

        [Route("GetResourcesOfDuties")]
        [HttpGet]
        public async Task<IEnumerable<ResourcesOfDutiesViewModel>> GetResourcesOfDutiesAsync()
        {
            return await _dutiesQueries.GetResourcesOfDutiesAsync();
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
