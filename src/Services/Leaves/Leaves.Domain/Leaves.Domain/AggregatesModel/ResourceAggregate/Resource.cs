using Leaves.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leaves.Domain.AggregatesModel.ResourceAggregate
{
    public class Resource : Entity, IAggregateRoot
    {
        public string ResourceCode { get; private set; }
        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method OrderAggrergateRoot.AddOrderItem() which includes behaviour.
        private readonly List<ResourceNotification> _resourceNotifications;
        public IReadOnlyCollection<ResourceNotification> ResourceNotifications => _resourceNotifications;

        public Resource(string resourceCode)
        {
            ResourceCode = !string.IsNullOrWhiteSpace(resourceCode) ? resourceCode : throw new ArgumentNullException(nameof(resourceCode));
            _resourceNotifications = new List<ResourceNotification>();
        }

        // DDD Patterns comment
        // This Order AggregateRoot's method "AddOrderitem()" should be the only way to add Items to the Order,
        // so any behavior (discounts, etc.) and validations are controlled by the AggregateRoot 
        // in order to maintain consistency between the whole Aggregate. 
        public void AddResourceNotification(int leaveId)
        {
            var existingNotificationLeaveForResource = _resourceNotifications.Where(x => x.LeaveId == leaveId).SingleOrDefault();
               
            if (existingNotificationLeaveForResource != null)
            {
                existingNotificationLeaveForResource.UpdateLastDate();
            }
            else
            {
                //add validated new order item

                var resourceNotification = new ResourceNotification(leaveId);
                _resourceNotifications.Add(resourceNotification);
            }
        }
    }
}
