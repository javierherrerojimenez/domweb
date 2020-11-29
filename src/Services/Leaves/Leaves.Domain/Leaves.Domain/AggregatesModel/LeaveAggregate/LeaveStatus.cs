using Leaves.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Domain.AggregatesModel.LeaveAggregate
{
    public class LeaveStatus : Enumeration
    {
        public static LeaveStatus Requested = new LeaveStatus(1, "Requested");
        public static LeaveStatus Accepted = new LeaveStatus(2, "Accepted");
        public static LeaveStatus Canceled = new LeaveStatus(3, "Canceled");
        public static LeaveStatus Refused = new LeaveStatus(4, "Refused");

        public LeaveStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
