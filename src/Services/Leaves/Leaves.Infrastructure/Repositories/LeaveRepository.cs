using Leaves.Domain.AggregatesModel.LeaveAggregate;
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
    public class LeaveRepository : ILeaveRepository
    {
        private readonly LeavesContext _context;
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }



        //public LeaveRepository(LeavesContext context)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //}

        //TODO:0.- Dejamos el constructor sin parametros hasta que se añada la inyección de dependencias del DBContext en el Startup
        public LeaveRepository()
        {

        }

        public Leave Add(Leave leave)
        {
            return _context.Leaves.Add(leave).Entity;
        }

        public async Task<Leave> GetAsync(int leaveId)
        {
            var leave = await _context
                                .Leaves
                                .Include(x => x.LeaveReason)
                                .FirstOrDefaultAsync(l => l.Id == leaveId);

            if (leave == null)
            {
                leave = _context
                            .Leaves
                            .Local
                            .FirstOrDefault(o => o.Id == leaveId);
            }
            if (leave != null)
            {
                //await _context.Entry(order)
                   // .Collection(i => i.OrderItems).LoadAsync();
                await _context.Entry(leave)
                   .Reference(i => i.LeaveStatus).LoadAsync();
                await _context.Entry(leave)
                    .Reference(i => i.LeaveStatus).LoadAsync(); //TODO: Quiero ver que pasa para los otros 2 enumerados cuando ejecute esto. No va a saber devolver el valor correctamente?
            }

            return leave;
        }

        public void Update(Leave leave)
        {
            _context.Entry(leave).State = EntityState.Modified;
        }

    }
}
