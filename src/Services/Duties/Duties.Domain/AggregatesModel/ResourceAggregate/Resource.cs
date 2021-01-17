using Duties.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Duties.Domain.AggregatesModel.ResourceAggregate
{
    public class Resource : Entity, IAggregateRoot
    {
        public string ResourceCode { get; private set; }

        public Resource(string resourceCode)
        {
            ResourceCode = !string.IsNullOrWhiteSpace(resourceCode) ? resourceCode : throw new ArgumentNullException(nameof(resourceCode));
        }
    }
}
