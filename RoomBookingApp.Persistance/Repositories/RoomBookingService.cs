﻿using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingApp.Persistance.Repositories
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly RoomBookingAppDbContext _context;
        public RoomBookingService(RoomBookingAppDbContext context)
        { 
            this._context = context;
        }
        public IEnumerable<Room> GetAvailableRooms(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Save(RoomBooking roomBooking)
        {
            throw new NotImplementedException();
        }
    }
}