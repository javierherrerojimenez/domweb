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
                context.Database.EnsureCreated(); // este método no ejecuta por defecto las migraciones, solo crea la base de datos
                //context.Database.Migrate();

                // Look for any user
                if (context.Resources.Any())
                {
                    return;   // DB has been seeded
                }

                var resources = new Resource[]
                {
                    new Resource ("ajones"),
                    new Resource ("amuhid")
                };

                foreach (Resource r in resources)
                {
                    context.Resources.Add(r);
                }

                context.SaveChangesAsync();
            }
            

            

            //var stocks = new Stock[]
            //    {
            //        new Stock{UserID = users.Single(x => x.UserName == "jherrero").UserID,
            //            Ticker = "SAN.MC", Price= 4.5f, BuyDate = DateTime.Now, Amount = 100 }
            //    };

            //foreach (Stock s in stocks)
            //{
            //    context.Stocks.Add(s);
            //}
            //context.SaveChanges();
        }
    }
}
