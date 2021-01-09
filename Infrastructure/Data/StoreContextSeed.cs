using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SyncAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.LstDogs.Any())
                {
                    var dogData = File.ReadAllText("../Infrastructure/Data/SeedData/lstDogs.json");
                    var dogs = JsonSerializer.Deserialize<IReadOnlyList<LstDog>>(dogData);

                    foreach (var dog in dogs)
                    {
                        context.LstDogs.Add(dog);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.LstOrders.Any())
                {
                    var orderData = File.ReadAllText("../Infrastructure/Data/SeedData/lstOrders.json");
                    var orders = JsonSerializer.Deserialize<IReadOnlyList<LstOrder>>(orderData);

                    foreach (var order in orders)
                    {
                        context.LstOrders.Add(order);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}