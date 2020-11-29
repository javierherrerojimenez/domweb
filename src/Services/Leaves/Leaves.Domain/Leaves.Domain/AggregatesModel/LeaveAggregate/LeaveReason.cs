using Leaves.Domain.Exceptions;
using Leaves.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Domain.AggregatesModel.LeaveAggregate
{
    /// <summary>
    /// La razon va es una clase hija del Leave, estas entidades si que van a tener un ID y esta razón solo pertenece a un Leave (habrá que ver si luego a nivel de base de datos esto será un catalogo cerrado o no)
    ///// </summary>
    //public class LeaveReason : Entity
    //{
    //    private string _description;
    //    public string Description { get => _description; private set => _description = value; }

    //    //public int IDReason { get; private set; } // Desde mi punto de vista creo que no hace falta crear esta propiedad ya que tenemos la propiedad ID de la clase base

    //    public LeaveReason() { }

    //    public LeaveReason(int leaveReasonId, string description)
    //    {
    //        if (leaveReasonId <= 0)
    //            throw new LeaveDomainException("IdLeaveReason invalid");

    //        if (string.IsNullOrEmpty(description))
    //            throw new LeaveDomainException("Description of LeaveReason invalid");


    //        Id = leaveReasonId;
    //        Description = description;
    //    }

    //    // Se pueden hacer este tipo de métodos para recuperar el valor pero yo prefiero tener la propiedad con 
    //    //public string GetLeaveReasonDescription() => _description;
    //}

    // <summary>
    // Se implementan los tipos como Value Object, es decir, serán inmutables(no pueden cambiar) y no tiene ID(al menos a nivel de Dominio)
    // </summary>
    public class LeaveReason : ValueObject
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public LeaveReason() { }

        public LeaveReason(string name, string description)
        {
            Name = name;
            Description = description;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Name;
            yield return Description;
        }
    }
}
