using Duties.Domain.Events;
using Duties.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Duties.Domain.AggregatesModel.DutyAggregate
{
    public class Duty : Entity, IAggregateRoot
    {
        // DDD Patterns comment
        // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)

        public int? GetResourceId => _resourceId;
        private int? _resourceId;

        public string Name { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public int HourStart { get; private set; }
        public int HourEnd { get; private set; }
        public string NodeStart { get; private set; }
        public string NodeEnd { get; private set; }

        private bool _isNew;
        private DateTime _createdTime;

        public Duty()
        {

        }

        public Duty(string userName, string name, DateTime dateStart, DateTime dateEnd, int hourStart, int hourEnd, string nodeStart, string nodeEnd, int? resourceId = null) : this()
        {
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            HourStart = hourStart;
            HourEnd = hourEnd;
            NodeStart = nodeStart;
            NodeEnd = nodeEnd;
            _resourceId = resourceId;

            _isNew = true;
            _createdTime = DateTime.UtcNow;

            // Add the AddLeaveStartedDomainEvent to the domain events collection 
            // to be raised/dispatched when comitting changes into the Database [ After DbContext.SaveChanges() ]
            AddDutyCreatedDomainEvent(userName);
        }

        private void AddDutyCreatedDomainEvent(string userName)
        {
            var dutyCreatedDomainEvent = new AddDutyCreatedDomainEvent(this, userName);
            this.AddDomainEvent(dutyCreatedDomainEvent);
        }

    }
}
