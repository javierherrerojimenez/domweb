using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leaves.API.Queries
{
    public class LeaveTypeViewModel
    {
        public int LeaveTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsPaid { get; set; }

    }
}
