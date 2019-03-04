﻿using LandonApi.Model;
using LandonApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet(Name = nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            throw new NotImplementedException();
        }

        //GET  /rooms/{roomId}
        [HttpGet("{roomId}", Name = nameof(GetRoomById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Room>> GetRoomById(Guid roomId)
        {
           var room =  await   _roomService.GetRoomAsync(roomId);
            if (room == null) return NotFound();

            return room;
        }
    }

}
