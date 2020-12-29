using Leaves.Domain.AggregatesModel.LeaveAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Domain.Events
{
    public class LeaveAcceptedDomainEvent : INotification
    {
        public Leave Leave { get; }

        public LeaveAcceptedDomainEvent(Leave leave)
        {
            Leave = leave;
        }
    }
}
