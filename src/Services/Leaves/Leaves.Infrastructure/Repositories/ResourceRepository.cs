using Leaves.Domain.AggregatesModel.ResourceAggregate;
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
    public class ResourceRepository : IResourceRepository
    {
        private readonly LeavesContext _context;
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public ResourceRepository(LeavesContext context)
        {
            // Evalua si es null en context que llega por parámetro
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Resource Add(Resource resource)
        {
            if (resource.IsTransient())
            {
                return _context.Resources
                    .Add(resource)
                    .Entity;
            }
            else
            {
                return resource;
            }
        }

        public Resource Update(Resource resource)
        {
            return _context.Resources
                    .Update(resource)
                    .Entity;
        }

        public async Task<Resource> FindAsync(string resourceCode)
        {
            var resource = await _context.Resources
                .Where(r => r.ResourceCode == resourceCode)
                .SingleOrDefaultAsync();

            return resource;
        }

        public async Task<Resource> FindByIdAsync(string id)
        {
            var resource = await _context.Resources
               .Where(r => r.Id == int.Parse(id))
               .SingleOrDefaultAsync();

            return resource;
        }

        
    }
}
