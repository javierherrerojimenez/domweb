using Leaves.Domain.Events;
using Leaves.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Leaves.Domain.AggregatesModel.LeaveAggregate
{
    public class Leave : Entity, IAggregateRoot
    {
        // DDD Patterns comment
        // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)

        public int? GetResourceId => _resourceId;
        private int? _resourceId;

        public int? GetLeaveTypeId => _leaveTypeId;
        private int? _leaveTypeId;

        public LeaveStatus LeaveStatus { get; private set; }
        private int _leaveStatusId;


        public LeaveReason LeaveReason { get; private set; }


        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public string Comments { get; private set; }

        private bool _isNew;

        private string _description;
        private DateTime _createDate;

        public Leave()
        {

        }

        public Leave(string userId, string userName, LeaveReason leaveReason, DateTime dateStart, DateTime dateEnd, string comments, int leaveTypeId,  int? resourceId = null) : this()
        {
            _resourceId = resourceId;
            _leaveTypeId = leaveTypeId;
            _leaveStatusId = LeaveStatus.Requested.Id;
  
            LeaveReason = leaveReason;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Comments = comments;

            _isNew = true;
            _createDate = DateTime.UtcNow;


            // Add the AddLeaveStartedDomainEvent to the domain events collection 
            // to be raised/dispatched when comitting changes into the Database [ After DbContext.SaveChanges() ]
            AddLeaveStartedDomainEvent(userId, userName);
        }

        private void AddLeaveStartedDomainEvent(string userId, string userName)
        {
            var leaveStartedDomainEvent = new LeaveStartedDomainEvent(this, userId, userName);

            this.AddDomainEvent(leaveStartedDomainEvent);
        }

        // DDD Patterns comment
        // This Leave AggregateRoot's method "AddLeaveType()" should be the only way to add Type to the Leave,
        // so any behavior (discounts, etc.) and validations are controlled by the AggregateRoot 
        // in order to maintain consistency between the whole Aggregate. 
        //public void SetLeaveType(int leaveTypeId, string name, string code, bool isPaid)
        //{
        //    var leaveType = new LeaveType(leaveTypeId, name, code, isPaid);
        //    LeaveType = leaveType;
        //    //var existingReasonForLeave = _leaveReasons.Where(o => o.Id == leaveReasonId)
        //    //    .SingleOrDefault();

        //    //if (existingReasonForLeave != null)
        //    //{
        //    //    //if previous line exist modify it with higher discount  and units..

        //    //    //if (discount > existingOrderForProduct.GetCurrentDiscount())
        //    //    //{
        //    //    //    existingOrderForProduct.SetNewDiscount(discount);
        //    //    //}

        //    //    //existingOrderForProduct.AddUnits(units);
        //    //}
        //    //else
        //    //{
        //    //    //add validated new order item

        //    //    var leaveReason = new LeaveType(leaveReasonId, description);
        //    //    _leaveReasons.Add(leaveReason);
        //    //}
        //}

      

        //TODO: He añadido el SetResourceId en comparación con el SetBuyerId que se llama desde UpdateOrderWhenBuyerAndPaymentMethodVerifiedDomainEventHandler en el proyecto API, hay que seguir ese hilo
        // https://docs.microsoft.com/es-es/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api
        public void SetResourceId(int id)
        {
            _resourceId = id;
        }

        public void SetRefusedStatus()
        {
            if (_leaveStatusId == LeaveStatus.Requested.Id)
            {
                //AddDomainEvent(new OrderStatusChangedToAwaitingValidationDomainEvent(Id, _orderItems));
                _leaveStatusId = LeaveStatus.Refused.Id;
            }
        }

        public void SetAcceptedStatus()
        {
            if (_leaveStatusId == LeaveStatus.Requested.Id)
            {
                //AddDomainEvent(new OrderStatusChangedToAwaitingValidationDomainEvent(Id, _orderItems));
                _leaveStatusId = LeaveStatus.Accepted.Id;
                _description = $"The leave was accepted.";
                AddDomainEvent(new LeaveAcceptedDomainEvent(this));
            }
        }

        public void SetCanceledStatus()
        {
            if (_leaveStatusId == LeaveStatus.Requested.Id)
            {
                //AddDomainEvent(new OrderStatusChangedToAwaitingValidationDomainEvent(Id, _orderItems));
                _leaveStatusId = LeaveStatus.Canceled.Id;
            }
        }
    }
}
