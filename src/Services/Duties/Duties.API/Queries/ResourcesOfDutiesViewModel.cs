using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duties.API.Queries
{
    public class ResourcesOfDutiesViewModel
    {
        public string ResourceCode { get; set; }
        public string DutyName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
