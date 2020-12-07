using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Domain.AggregatesModel.LeaveTypeAggregate;
using Leaves.Domain.AggregatesModel.ResourceAggregate;
using Leaves.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leaves.API.Infrastructure
{
    /// <summary>
    /// Clase que inicializa y alimenta la base de datos
    /// </summary>
    public class LeavesContextSeed
    {
        public static void Initialize(LeavesContext context)
        {

            using (context)
            {
                //context.Database.EnsureCreated(); // este método no ejecuta por defecto las migraciones, solo crea la base de datos
                context.Database.Migrate();

                // Look for any user
                if (context.Resources.Any())
                {
                    return;   // DB has been seeded
                }

                //Resources
                var resources = new Resource[]
                {
                    new Resource ("ajones"),
                    new Resource ("amuhid")
                };

                foreach (Resource r in resources)
                {
                    context.Resources.Add(r);
                }

                // Leave Types
                var leaveTypes = new LeaveType[]
                {
                    new LeaveType("Baja", "B", true),
                    new LeaveType("AnualLeave", "AL")
                };

                foreach (var leaveType in leaveTypes)
                {
                    context.LeaveTypes.Add(leaveType);
                }

                // Leave Status
                foreach (LeaveStatus s in GetLeaveStatus())
                {
                    context.LeaveStatus.Add(s);
                }


                //context.SaveChangesAsync();
                context.SaveChanges();
            }

        }

        private static IEnumerable<LeaveStatus> GetLeaveStatus()
        {
            return new List<LeaveStatus>()
            {
                LeaveStatus.Requested,
                LeaveStatus.Accepted,
                LeaveStatus.Canceled,
                LeaveStatus.Refused
            };
        }
    }
}
