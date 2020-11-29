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

        //Se usa DI en el constructor tanto para el mediator como para repositorio de Leaves
        public CreateLeaveCommandHandler(IMediator mediator, ILeaveRepository leaveRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
            _leaveRepository = leaveRepository ?? throw new ArgumentNullException(nameof(leaveRepository)); ;
        }

        public async Task<bool> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
        {
            // Add/Update the Leave AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate

            //TODO: 1. - Hacer la query para rellenar el ViewModel. Estos ViewModel que devuelven las queries se pueden usar tanto para devolver por la API una estructura o de entrada al modelo DDD.
            LeaveTypeViewModel leaveTypeVM = new LeaveTypeViewModel();
            LeaveReason leaveReason = new LeaveReason(request.LeaveReason.Name, request.LeaveReason.Description);
            
            var leave = new Leave(request.IdUser, request.UserName, leaveReason, request.DateStart, request.DateEnd, request.Comments, request.ResourceId);

            //TODO 2.- Recuperar con una query los Tipos en base de datos y chequear si existe el tipo. Una vez chequeado ya se mete en el objeto leave
            // List<LeaveReasonViewModel>
            leave.AddLeaveType(1, "", "");
  

            //_logger.LogInformation("----- Creating Order - Order: {@Order}", order);

            //_leaveRepository.Add(leave);

            return await _leaveRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
