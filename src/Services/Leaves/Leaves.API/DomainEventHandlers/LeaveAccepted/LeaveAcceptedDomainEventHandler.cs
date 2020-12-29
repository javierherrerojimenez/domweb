using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Domain.AggregatesModel.ResourceAggregate;
using Leaves.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Leaves.API.DomainEventHandlers.LeaveAccepted
{
    public class LeaveAcceptedDomainEventHandler : INotificationHandler<LeaveAcceptedDomainEvent>
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IResourceRepository _resourceRepository;

        public LeaveAcceptedDomainEventHandler(ILeaveRepository leaveRepository, IResourceRepository resourceRepository)
        {
            _leaveRepository = leaveRepository;
            _resourceRepository = resourceRepository;
        }

        public async Task Handle(LeaveAcceptedDomainEvent leaveAcceptedDomainEvent, CancellationToken cancellationToken)
        {
            //_logger.CreateLogger<OrderCancelledDomainEvent>()
            //   .LogTrace("Order with Id: {OrderId} has been successfully updated to status {Status} ({Id})",
            //       orderCancelledDomainEvent.Order.Id, nameof(OrderStatus.Cancelled), OrderStatus.Cancelled.Id);

            // Añade la notificación del cambio de estado del Leave a la entidad Resource
            var leave = await _leaveRepository.GetAsync(leaveAcceptedDomainEvent.Leave.Id);
            if (leave != null)
            {
                var resource = await _resourceRepository.FindByIdAsync(leave.GetResourceId != null ? leave.GetResourceId.ToString() : "0");
                resource.AddResourceNotification(leave.Id);
            }

            //var buyer = await _buyerRepository.FindByIdAsync(order.GetBuyerId.Value.ToString());

            //var orderStatusChangedToCancelledIntegrationEvent = new OrderStatusChangedToCancelledIntegrationEvent(order.Id, order.OrderStatus.Name, buyer.Name);
            //await _orderingIntegrationEventService.AddAndSaveEventAsync(orderStatusChangedToCancelledIntegrationEvent);
        }
    }
}
