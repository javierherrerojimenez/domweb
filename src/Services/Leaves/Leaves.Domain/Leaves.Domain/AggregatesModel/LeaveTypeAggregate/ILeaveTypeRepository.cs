using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leaves.Domain.AggregatesModel.LeaveTypeAggregate
{
    public interface ILeaveTypeRepository
    {
        LeaveType Add(LeaveType leaveType);
        LeaveType Update(LeaveType leaveType);
        Task<LeaveType> FindAsync(string code);
        Task<LeaveType> FindByIdAsync(string id);
    }
}

