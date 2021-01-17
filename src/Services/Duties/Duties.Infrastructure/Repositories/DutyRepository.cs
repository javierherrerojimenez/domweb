using Duties.Domain.AggregatesModel.DutyAggregate;
using Duties.Domain.SeedWork;
using Duties.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duties.Infrastructure.Repositories
{
    public class DutyRepository : IDutyRepository
    {
        private readonly DutiesContext _context;
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public DutyRepository(DutiesContext context)
        {
            // Evalua si es null en context que llega por parámetro
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Duty Add(Duty duty)
        {
            if (duty.IsTransient())
            {
                return _context.Duties
                    .Add(duty)
                    .Entity;
            }
            else
            {
                return duty;
            }
        }

        public async Task<Duty> FindByIdAsync(string id)
        {
            var duty = await _context.Duties
                .Where(d => d.Id == int.Parse(id))
                .SingleOrDefaultAsync();

            return duty;
        }

        public Duty Update(Duty duty)
        {
            return _context.Duties
                     .Update(duty)
                     .Entity;
        }
    }
}
