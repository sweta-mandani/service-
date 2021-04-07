using AutoMapper;
using DealerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerManagement.DAL
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vehicle, VehicleView>();
                cfg.CreateMap<VehicleView, Vehicle>();
                cfg.CreateMap<Customer, UserView>();
                cfg.CreateMap<UserRegistration, Customer>();
                cfg.CreateMap<Mechanic, MechanicView>();
                cfg.CreateMap<MechanicView, Mechanic>();
                cfg.CreateMap<Service, ServiceView>();
                cfg.CreateMap<ServiceView, Service>();
                cfg.CreateMap<Booking, BookingView>();
                cfg.CreateMap<BookingView, Booking>();
            });
            Mapper = config.CreateMapper();
        }
    }
}
