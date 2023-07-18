using Xunit;
using Shouldly;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Processors;
using RoomBookingApp.Core.DataServices;
using Moq;


namespace RoomBookingAppCore
{
    public class RoomBookingRequestProcessorTest
    {
        private RoomBookingRequestProcessor _processor;
        private RoomBookingRequest _request;
        private Mock<IRoomBookingService> _roomBookingServiceMock;

        public RoomBookingRequestProcessorTest()
        {
            
            _request = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@request.com",
                Date = new DateTime(2021, 10, 20)
            };

            _roomBookingServiceMock = new Mock<IRoomBookingService>();
            _processor = new RoomBookingRequestProcessor(_roomBookingServiceMock.Object);
        }

        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {

            //Act
            RoomBookingResult result = _processor.BookRoom(_request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_request.FullName, result.FullName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);

            //result.ShouldNotBeNull();
            //result.FullName.ShouldBe(request.FullName);
            //result.Email.ShouldBe(request.Email);
            //result.Date.ShouldBe(request.Date);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookRoom(null));

            exception.ParamName.ShouldBe("bookingRequest");
        }

        [Fact]
        public void Should_Save_Room_Booking_Request()
        {
            RoomBooking savedBooking = null;
            _roomBookingServiceMock.Setup(q => q.Save(It.IsAny<RoomBooking>()))
                .Callback<RoomBooking>(booking =>
                {
                    savedBooking = booking;
                });

            _processor.BookRoom(_request);
            _roomBookingServiceMock.Verify(q => q.Save(It.IsAny<RoomBooking>()), Times.Once);

            savedBooking.ShouldNotBeNull();
            savedBooking.FullName.ShouldBe(_request.FullName);
            savedBooking.Email.ShouldBe(_request.Email);
            savedBooking.Date.ShouldBe(_request.Date);
        }
    }
}
