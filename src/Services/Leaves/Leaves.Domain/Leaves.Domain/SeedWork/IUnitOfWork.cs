using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leaves.Domain.SeedWork
{
    /// <summary>
    /// Descripción: Este intefaz será implementado en la capa de Infraestructura al igual que los repositorios (en este caso concreto que se implementará en el DBContext de la Infraestructura)
    ///              Mantiene la lista de objetos afectado por una transacción y coordina la persistencia de los datos y la resolución de problemas de concurrencia. 
    ///              En este caso, mantendremos un único DbContext para todos los agregados y de esta forma se podrá generar todas las modificaciones con una sola transacción
    /// Referencia: https://docs.microsoft.com/es-es/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
