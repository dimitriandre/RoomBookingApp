using Microsoft.AspNetCore.Mvc;
using RoomBookingApp.Core.Processors;
using RoomBookingApp.Domain.BaseModels;

namespace RoomBookingApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomBookingController : Controller
    {
        private IRoomBookingRequestProcessor _roomBookingRequestProcessor;

        public RoomBookingController(IRoomBookingRequestProcessor roomBookingRequestProcessor)
        {
            this._roomBookingRequestProcessor = roomBookingRequestProcessor;
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom(RoomBookingRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _roomBookingRequestProcessor.BookRoom(request);
                if(result.Flag == Core.Enums.BookingResultFlag.Success)
                {
                    return Ok(result);
                }

                ModelState.AddModelError(nameof(RoomBookingRequest.Date), "No rooms available for a given date.");
            }

            return BadRequest(ModelState);
        }
    }
}
