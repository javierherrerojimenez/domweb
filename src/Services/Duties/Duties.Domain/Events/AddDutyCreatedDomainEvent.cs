using Duties.Domain.AggregatesModel.DutyAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Duties.Domain.Events
{
    public class AddDutyCreatedDomainEvent : INotification
    {
        public string UserName { get; private set; }
        public Duty Duty { get; private set; }

        public AddDutyCreatedDomainEvent(Duty duty, string userName)
        {
            Duty = duty;
            UserName = userName;
        }
    }
}
