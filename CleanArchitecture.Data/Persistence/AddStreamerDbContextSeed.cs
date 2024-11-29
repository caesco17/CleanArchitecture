using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class AddStreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<AddStreamerDbContextSeed> logger) 
        { 
            if(context.Streamers!.Any())
            {
                logger.LogInformation("The database has already been seeded.");
                return;
            }
            else
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamers());
                await context.SaveChangesAsync();
                logger.LogInformation("Adding seed records to db {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamers()
        {
            return new List<Streamer>
            {
                new Streamer { Name = "Streamer 1", Url = "https://www.hbp1.com", CreatedBy = "System"},
                new Streamer { Name = "Streamer 2", Url = "https://www.hbp2.com", CreatedBy = "System"},
                new Streamer { Name = "Streamer 3", Url = "https://www.hbp3.com", CreatedBy = "System"},
                new Streamer { Name = "Streamer 4", Url = "https://www.hbp4.com", CreatedBy = "System"},
                new Streamer { Name = "Streamer 5", Url = "https://www.hbp5.com", CreatedBy = "System"}
            };
        }
    }
}
