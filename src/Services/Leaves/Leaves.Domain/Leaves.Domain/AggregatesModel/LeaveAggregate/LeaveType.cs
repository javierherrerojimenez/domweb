using Leaves.Domain.Exceptions;
using Leaves.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Domain.AggregatesModel.LeaveAggregate
{
    /// <summary>
    /// Se implementan los tipos como Value Object, es decir, serán inmutables (no pueden cambiar) y no tiene ID (al menos a nivel de Dominio)
    /// </summary>
    //public class LeaveType : ValueObject
    //{
    //    // Ejemplos de tipo de Leave son "Holidays", "Maternity" ...

    //    public String Code { get; private set; }
    //    public String Name { get; private set; }
    //    public bool IsPaid { get; private set; }

    //    public LeaveType() { }

    //    public LeaveType(string code, string name, bool isPaid)
    //    {
    //        Code = code;
    //        Name = name;
    //        IsPaid = isPaid;
    //    }

    //    protected override IEnumerable<object> GetAtomicValues()
    //    {
    //        // Using a yield return statement to return each element one at a time
    //        yield return Code;
    //        yield return Name;
    //        yield return IsPaid;
    //    }
    //}

    /// <summary>
    /// El tipo va es una clase hija del Leave, estas entidades si que van a tener un ID y esta razón solo pertenece a un Leave (habrá que ver si luego a nivel de base de datos esto será un catalogo cerrado o no)
    /// </summary>
    public class LeaveType : Entity
    {
        // Ejemplos de tipo de Leave son "Holidays", "Maternity" ...
        private string _name;
        private string _code;
        private bool _isPaid;

        public string Name { get => _name; private set => _name = value; }
        public string Code { get => _code; private set => _code = value; }
        public bool IsPaid { get => _isPaid; private set => _isPaid = value; }


        //public int IDReason { get; private set; } // Desde mi punto de vista creo que no hace falta crear esta propiedad ya que tenemos la propiedad ID de la clase base

        public LeaveType() { }

        public LeaveType(int leaveTypeId, string name, string code, bool isPaid = false)
        {
            if (leaveTypeId <= 0)
                throw new LeaveDomainException("leaveTypeId invalid");

            if (string.IsNullOrEmpty(code))
                throw new LeaveDomainException("Code of LeaveType invalid");

            if (string.IsNullOrEmpty(name))
                throw new LeaveDomainException("Name of LeaveType invalid");


            Id = leaveTypeId;
            Name = name;
            Code = code;
            IsPaid = isPaid;
        }

        public LeaveType(string name, string code, bool isPaid = false)
        {

            if (string.IsNullOrEmpty(code))
                throw new LeaveDomainException("Code of LeaveType invalid");

            if (string.IsNullOrEmpty(name))
                throw new LeaveDomainException("Name of LeaveType invalid");

            Name = name;
            Code = code;
            IsPaid = isPaid;
        }

        // Se pueden hacer este tipo de métodos para recuperar el valor pero yo prefiero tener la propiedad con 
        //public string GetLeaveReasonDescription() => _description;
    }
}
