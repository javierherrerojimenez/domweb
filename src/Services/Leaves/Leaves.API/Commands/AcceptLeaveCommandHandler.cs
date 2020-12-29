using Leaves.Domain.AggregatesModel.LeaveAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Leaves.API.Commands
{
    public class AcceptLeaveCommandHandler : IRequestHandler<AcceptLeaveCommand, bool>
    {
        private readonly ILeaveRepository _leaveRepository;

        public AcceptLeaveCommandHandler(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public async Task<bool> Handle(AcceptLeaveCommand request, CancellationToken cancellationToken)
        {
            // Add/Update the Leave AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate


            // Recupera el los LeaveType para comprobar que es un ID correcto, se ha hecho solo a modo de ejemplo, se podría hacer lo mismo para el ResourceId
            var leave = await _leaveRepository.GetAsync(request.LeaveId);

            if (leave == null)
            {
                return false;
            }

            leave.SetAcceptedStatus();
            return await _leaveRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
