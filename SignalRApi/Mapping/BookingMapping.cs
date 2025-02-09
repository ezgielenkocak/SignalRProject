using AutoMapper;
using Microsoft.EntityFrameworkCore.Update;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, ResultBookingDto>();
            CreateMap<Booking, CreateBookingDto>();
            CreateMap<Booking, UpdateBookingDto>();
            CreateMap<Booking, GetBookingDto>();
        }
    }
}
