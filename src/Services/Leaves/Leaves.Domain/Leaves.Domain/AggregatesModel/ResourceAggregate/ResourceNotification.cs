using Leaves.Domain.Exceptions;
using Leaves.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Leaves.Domain.AggregatesModel.ResourceAggregate
{
    public class ResourceNotification : Entity
    {
        // DDD Patterns comment
        // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
        private DateTime _lastUpdate;
        public int LeaveId { get; private set; }

        public ResourceNotification(int leaveId)
        {
            if (leaveId <= 0)
                throw new LeaveDomainException("leaveId Invalid");

            LeaveId = leaveId;
            _lastUpdate = DateTime.Now;
        }

        public void UpdateLastDate()
        {
            _lastUpdate = DateTime.Now;
        }
    }
}
