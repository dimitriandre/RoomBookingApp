using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingApp.Domain.BaseModels;

namespace RoomBookingApp.Core.DataServices
{
    public interface IRoomBookingService
    {
        void Save(RoomBooking roomBooking);
        IEnumerable<Room> GetAvailableRooms(DateTime date);
    }
}
