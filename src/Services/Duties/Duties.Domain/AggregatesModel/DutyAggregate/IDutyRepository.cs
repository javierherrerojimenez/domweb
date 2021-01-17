using Duties.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Duties.Domain.AggregatesModel.DutyAggregate
{
    public interface IDutyRepository : IRepository<Duty>
    {
        Duty Add(Duty duty);
        Duty Update(Duty duty);
       // Task<Duty> FindAsync(string resourceCode);
        Task<Duty> FindByIdAsync(string id);
    }
}
