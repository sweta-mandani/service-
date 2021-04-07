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
    public class ServiceRepository:IServiceRepository
    {
        private SBSEntities db = new SBSEntities();
        private IUserRepository _userrepository;
        private readonly IMapper mapper;
        public ServiceRepository(IUserRepository userRepository)
        {
            _userrepository = userRepository;
            AutoMapperConfig.init();
            mapper = AutoMapperConfig.Mapper;
        }
        public void AddService(ServiceView service)
        {
            Service services = mapper.Map<ServiceView, Service>(service);
            db.Services.Add(services);
            db.SaveChanges();
        }


        public IEnumerable<ServiceView> GetServices()
        {
            IEnumerable<Service> slist = db.Services;
            IEnumerable<ServiceView> services = slist.Select(x => mapper.Map<Service, ServiceView>(x)).ToList();

            return services;
        }

        public ServiceView GetService(int? id)
        {
            Service s = db.Services.Find(id);
            if (s == null)
            {
                return null;
            }
            ServiceView service = mapper.Map<Service, ServiceView>(s);
            return service;

        }

        public void UpdateService(ServiceView service)
        {
            Service services = db.Services.Find(service.Id);
            services.ServiceName = service.ServiceName ;
            services.Status = service.Status;
            services.Price = service.Price;
            services.Duration = service.Duration;

            db.Entry(services).State = EntityState.Modified;
        }

        public void RemoveService(int id)
        {
            Mechanic v = db.Mechanics.Find(id);
            db.Mechanics.Remove(v);
            db.SaveChanges();
        }
    }
}
