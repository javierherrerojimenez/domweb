using Leaves.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leaves.Domain.AggregatesModel.LeaveAggregate
{

    public interface ILeaveRepository : IRepository<Leave>
    {
        Leave Add(Leave leave);

        void Update(Leave leave);

        Task<Leave> GetAsync(int leaveId);
    }
}
