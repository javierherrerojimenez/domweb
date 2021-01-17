using Duties.Domain.AggregatesModel.DutyAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Duties.API.Commands
{
    public class CreateDutyCommandHandler : IRequestHandler<CreateDutyCommand, bool>
    {
        private IDutyRepository _dutyRepository;
        public CreateDutyCommandHandler(IDutyRepository dutyRepository)
        {
            _dutyRepository = dutyRepository;
        }

        public async Task<bool> Handle(CreateDutyCommand request, CancellationToken cancellationToken)
        {
            // Add/Update the Leave AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate

            Duty duty = new Duty(request.UserName, request.Name, request.DateStart, request.DateEnd, request.HourStart, request.HourEnd, request.NodeStart, request.NodeEnd, request.ResourceId);

           // _logger.LogInformation("----- Creating Order - Order: {@Order}", order);

            _dutyRepository.Add(duty);

            return await _dutyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
