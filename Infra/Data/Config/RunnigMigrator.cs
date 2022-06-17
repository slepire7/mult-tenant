using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Config
{
    public class RunnigMigrator
    {
        public static async Task ContextSeed(Data.AllDbTenantsContext context, ILoggerFactory logger)
        {
            if (!context.Clientes.Any())
            {
                context.Clientes.Add(new()
                {
                    Nome = "Jon lemon"
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
