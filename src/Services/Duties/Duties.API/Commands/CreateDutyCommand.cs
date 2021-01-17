using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duties.API.Commands
{
    public class CreateDutyCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public int ResourceId { get;  set; }
        public string Name { get;  set; }
        public DateTime DateStart { get;  set; }
        public DateTime DateEnd { get;  set; }
        public int HourStart { get;  set; }
        public int HourEnd { get;  set; }
        public string NodeStart { get;  set; }
        public string NodeEnd { get;  set; }

        public CreateDutyCommand()
        {

        }

        public CreateDutyCommand(int resourceId, string name, DateTime dateStart, DateTime dateEnd, int hourStart, int hourEnd, string nodeStart, string nodeEnd) //: this()
        {
            ResourceId = resourceId;
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            HourStart = hourStart;
            HourEnd = hourEnd;
            NodeStart = nodeStart;
            NodeEnd = nodeEnd;
        }
    }
}
