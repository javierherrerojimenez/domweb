using Duties.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Duties.Domain.AggregatesModel.ResourceAggregate
{
    public interface IResourceRepository : IRepository<Resource>
    {
        Resource Add(Resource resource);
        Resource Update(Resource resource);
        Task<Resource> FindAsync(string resourceCode);
        Task<Resource> FindByIdAsync(string id);
    }
}
