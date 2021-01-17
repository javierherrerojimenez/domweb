using Duties.Domain.AggregatesModel.ResourceAggregate;
using Duties.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duties.API.Infrastructure
{
    public class DutiesContextSeed
    {
        public static void Initialize(DutiesContext context)
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


                //context.SaveChangesAsync();
                context.SaveChanges();
            }

        }
    }
}
