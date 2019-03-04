using LandonApi.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddTestData(service.GetRequiredService<HotelDbContext>());
        }
        public static async Task AddTestData(HotelDbContext context)
        {
            if (context.Rooms.Any())
            {
                //Already had data
                return;
            }
            context.Rooms.Add( new RoomEntity {
                Id =    Guid.Parse("5636a75e-6dc8-4e9c-87b4-0c01da069e61"),
                Name = "Oxford Suite",
                Rate = 10119
            });
            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("06298abe-4747-4e4b-8d18-66c4f86aa6d8"),
                Name = "Driscoll Suite",
                Rate = 34454
            });
            await context.SaveChangesAsync();
        }
    }
}
