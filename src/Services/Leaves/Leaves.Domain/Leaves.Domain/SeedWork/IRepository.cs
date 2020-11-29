using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Domain.SeedWork
{
    /// <summary>
    /// Descripción: Intefaz base del cual heredan todos los interfaces de repositorio para cada agregado. La idea es que solo se puedan crear repositorios de Entidades que son Root, 
    /// de esta forma se asegura un único repositorio por agregado
    /// La propiedad UnitOfWork es la encargada de gestionar todas las modificaciones en una única transacción, en este caso, en la capa de Infraestructura esto se gestionará con un DBContext
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
