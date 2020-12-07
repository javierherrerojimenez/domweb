using Leaves.Domain.AggregatesModel.LeaveTypeAggregate;
using Leaves.Domain.SeedWork;
using Leaves.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaves.Infrastructure.Repositories
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly LeavesContext _context;
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public LeaveTypeRepository(LeavesContext context)
        {
            // Evalua si es null en context que llega por parámetro
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public LeaveType Add(LeaveType leaveType)
        {
            if (leaveType.IsTransient())
            {
                return _context.LeaveTypes
                    .Add(leaveType)
                    .Entity;
            }
            else
            {
                return leaveType;
            }
        }

        public LeaveType Update(LeaveType leaveType)
        {
            return _context.LeaveTypes
                    .Update(leaveType)
                    .Entity;
        }

        public async Task<LeaveType> FindAsync(string code)
        {
            var leaveType = await _context.LeaveTypes
                                    .Where(l => l.Code == code)
                                    .SingleOrDefaultAsync();

            return leaveType;
        }

        public async Task<LeaveType> FindByIdAsync(string id)
        {
            var leaveType = await _context.LeaveTypes
              .Where(r => r.Id == int.Parse(id))
              .SingleOrDefaultAsync();

            return leaveType;
        }

        
    }
}
