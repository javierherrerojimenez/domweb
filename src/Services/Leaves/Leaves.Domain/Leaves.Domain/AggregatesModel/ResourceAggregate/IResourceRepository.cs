using Leaves.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leaves.Domain.AggregatesModel.ResourceAggregate
{
    /// <summary>
    /// Descripción: Intefaz del ResourceAggregate que debe ser implementado en la capa de Infraestructura
    /// </summary>
    public interface IResourceRepository : IRepository<Resource>
    {
        Resource Add(Resource resource);
        Resource Update(Resource resource);
        Task<Resource> FindAsync(string resourceCode);
        Task<Resource> FindByIdAsync(string id);
    }
}
