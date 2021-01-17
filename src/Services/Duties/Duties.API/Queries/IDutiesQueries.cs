using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duties.API.Queries
{
    public interface IDutiesQueries
    {
        Task<IEnumerable<ResourcesOfDutiesViewModel>> GetResourcesOfDutiesAsync();
    }
}
