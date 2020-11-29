using Leaves.Domain.AggregatesModel.LeaveAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Domain.Events
{
    public class LeaveStartedDomainEvent : INotification
    {
        public string UserId { get; }
        public string UserName { get; }
        public Leave Leave { get; }

        public LeaveStartedDomainEvent(Leave leave, string userId, string userName)
        {
            Leave = leave;
            UserId = userId;
            UserName = userName;
        }
    }
}
