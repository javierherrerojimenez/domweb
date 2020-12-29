using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Leaves.API.Queries;
using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Domain.SeedWork;
using MediatR;

namespace Leaves.API.Commands
{
    /// <summary>
    /// Comando que crea un nuevo Leave
    /// </summary>
    public class CreateLeaveCommandHandler : IRequestHandler<CreateLeaveCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly ILeaveRepository _leaveRepository;
        private readonly ILeaveQueries _leaveQueries;

        //Se usa DI en el constructor tanto para el mediator como para repositorio de Leaves
        public CreateLeaveCommandHandler(IMediator mediator, ILeaveRepository leaveRepository, ILeaveQueries leaveQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); 
            _leaveRepository = leaveRepository ?? throw new ArgumentNullException(nameof(leaveRepository)); 
            _leaveQueries = leaveQueries ?? throw new ArgumentNullException(nameof(leaveQueries));
        }

        public async Task<bool> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
        {
            // Add/Update the Leave AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate

           
            // Recupera el los LeaveType para comprobar que es un ID correcto, se ha hecho solo a modo de ejemplo, se podría hacer lo mismo para el ResourceId
            LeaveReason leaveReason = new LeaveReason(request.LeaveReason.Name, request.LeaveReason.Description);
            var leaveTypes = await _leaveQueries.GetLeaveTypesAsync();

            var selectedType = leaveTypes.Where(x => x.Id == request.LeaveTypeId).FirstOrDefault();

            if (selectedType != null)
            {
                var leave = new Leave(request.IdUser, request.UserName, leaveReason, request.DateStart, request.DateEnd, request.Comments, request.LeaveTypeId, request.ResourceId);
                //_logger.LogInformation("----- Creating Order - Order: {@Order}", order);
                _leaveRepository.Add(leave);

                return await _leaveRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }

            return false;
        }
    }
}
