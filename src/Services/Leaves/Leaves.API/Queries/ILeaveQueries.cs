using Leaves.Domain.AggregatesModel.LeaveAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leaves.API.Queries
{
    public interface ILeaveQueries
    {
        Task<IEnumerable<LeaveTypeViewModel>> GetLeaveTypesAsync();
    }
}
