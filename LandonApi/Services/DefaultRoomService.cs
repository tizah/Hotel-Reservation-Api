using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LandonApi.Model;
using Microsoft.EntityFrameworkCore;

namespace LandonApi.Services
{
    public class DefaultRoomService : IRoomService
    {
        private readonly HotelDbContext _ctx;

        private readonly IMapper _mapper;

        public DefaultRoomService(HotelDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<Room> GetRoomAsync(Guid id)
        {
            var entity = await _ctx.Rooms.SingleOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
            {
                return null;//NotFound();
            }

            return _mapper.Map<Room>(entity);

         
        }
    }
}
