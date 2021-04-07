
using AutoMapper;
using DealerManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerManagement.DAL.Repository
{
    public class BookingRepository:IBookingRepository
    {
        private SBSEntities db = new SBSEntities();
        private IUserRepository _userrepository;
        private readonly IMapper mapper;
        public BookingRepository(IUserRepository userRepository)
        {
            _userrepository = userRepository;
            AutoMapperConfig.init();
            mapper = AutoMapperConfig.Mapper;
        }
        public IEnumerable<BookingView> GetBookings(string username)
        {
            UserView user = _userrepository.findUser(username);
            IEnumerable<Booking> blist = db.Bookings.Where(m => m.UserId == user.Id).AsEnumerable();
            IEnumerable<BookingView> bookings = blist.Select(x => mapper.Map<Booking, BookingView>(x)).ToList();

            return bookings;
        }

        public BookingView GetBooking(int? id)
        {
            Booking b = db.Bookings.Find(id);
            if (b == null)
            {
                return null;
            }
            BookingView booking = mapper.Map<Booking, BookingView>(b);
            return booking;

        }

        public void AddBooking(string name, BookingView booking)
        {
            UserView user = _userrepository.findUser(name);
            Booking bookings = mapper.Map<BookingView, Booking>(booking);
            bookings.UserId = user.Id;
            bookings.Status = "Pending";
            db.Bookings.Add(bookings);
            db.SaveChanges();

        }

        public void UpdateBooking(BookingView booking)
        {
            Booking bookings = db.Bookings.Find(booking.Id);
            bookings.ServiceId = booking.ServiceId;
            bookings.UserId = booking.UserId;
            bookings.VehicleId = booking.VehicleId;
            bookings.StartTime = booking.StartTime;
            bookings.Status = booking.Status;
            bookings.EndTime = booking.EndTime;
            db.Entry(bookings).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveBooking(int id)
        {
            Booking b = db.Bookings.Find(id);
            db.Bookings.Remove(b);
            db.SaveChanges();

        }

        public IEnumerable<BookingView> GetBookings()
        {
            IEnumerable<Booking> blist = db.Bookings;
            IEnumerable<BookingView> bookings = blist.Select(x => mapper.Map<Booking, BookingView>(x)).ToList();

            return bookings;
        }

        public void ChangeStatus(int? id, string status)
        {
            Booking b = db.Bookings.Find(id);
            b.Status = status;
            db.Entry(b).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
