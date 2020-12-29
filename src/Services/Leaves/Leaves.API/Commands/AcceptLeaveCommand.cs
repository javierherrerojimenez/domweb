using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Leaves.API.Commands
{
    public class AcceptLeaveCommand : IRequest<bool>
    {
        [DataMember]
        public int LeaveId { get; set; }

        public AcceptLeaveCommand() { }

        public AcceptLeaveCommand(int leaveId)
        {
            LeaveId = leaveId;
        }
    }
}
