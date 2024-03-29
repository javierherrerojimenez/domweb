﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Leaves.API.Commands
{
    // DDD and CQRS patterns comment: Note that it is recommended to implement immutable Commands
    // In this case, its immutability is achieved by having all the setters as private
    // plus only being able to update the data just once, when creating the object through its constructor.
    // References on Immutable Commands:  
    // http://cqrs.nu/Faq
    // https://docs.spine3.org/motivation/immutability.html 
    // http://blog.gauffin.org/2012/06/griffin-container-introducing-command-support/
    // https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties
    // Esta clase es un DTO 

    [DataContract]
    public class CreateLeaveCommand : IRequest<bool>
    {
        [DataMember]
        public string IdUser { get;  set; } //TODO: Duda - Es realmente necesario el IdUser en el DTO? Yo pienso que no, es decir, o se recibe el Id o se recibe el userName

        [DataMember]
        public string UserName { get;  set; }

        [DataMember]
        public int ResourceId { get;  set; }

        //public string LeaveStatus { get; private set; } El Status siempre se inicializa y ya está

        [DataMember]
        public int LeaveTypeId { get;  set; }

        [DataMember]
        public LeaveReasonDTO LeaveReason { get;  set; }

        [DataMember]
        public DateTime DateStart { get;  set; }

        [DataMember]
        public DateTime DateEnd { get;  set; }

        [DataMember]
        public string Comments { get;  set; }

        public CreateLeaveCommand()
        {

        }

        public CreateLeaveCommand(string userName, int resourceId, int leaveTypeId, LeaveReasonDTO leaveReason, DateTime dateStart, DateTime dateEnd, string comments) : this()
        {
            UserName = userName;
            ResourceId = resourceId;
            LeaveTypeId = leaveTypeId;
            LeaveReason = leaveReason;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Comments = comments;
        }

    }

}
