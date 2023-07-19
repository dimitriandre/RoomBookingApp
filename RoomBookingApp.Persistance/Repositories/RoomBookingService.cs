using RoomBookingApp.Core.DataServices;
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
            var unAvailableRooms = _context.RoomBookings.Where(q => q.Date == date).Select(q => q.RoomId).ToList();

            var availableRooms = _context.Rooms.Where(q => unAvailableRooms.Contains(q.Id) == false).ToList();

            return availableRooms;
        }

        public void Save(RoomBooking roomBooking)
        {
            throw new NotImplementedException();
        }
    }
}
