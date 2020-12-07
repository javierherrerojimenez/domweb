using Leaves.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Leaves.Domain.AggregatesModel.LeaveTypeAggregate
{
    public class LeaveType : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public bool IsPaid { get; private set; }

        public LeaveType(string name, string code, bool isPaid = false)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name)); 
            Code = !string.IsNullOrWhiteSpace(code) ? code : throw new ArgumentNullException(nameof(code));
            IsPaid = isPaid;
        }
    }
}
