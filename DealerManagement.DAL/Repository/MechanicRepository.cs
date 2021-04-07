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
    public class MechanicRepository : IMechanicRepository
    {
        private SBSEntities db = new SBSEntities();
        private readonly IMapper mapper;
        public MechanicRepository()
        {
            AutoMapperConfig.init();
            mapper = AutoMapperConfig.Mapper;
        }
        public void AddMechanic( MechanicView mechanic)
        {
            Mechanic mechanics = mapper.Map<MechanicView, Mechanic>(mechanic);
            db.Mechanics.Add(mechanics);
            db.SaveChanges();
        }

        
        public IEnumerable<MechanicView> GetMechanics()
        {
            IEnumerable<Mechanic> mlist = db.Mechanics;
            IEnumerable<MechanicView> mechanics = mlist.Select(x => mapper.Map<Mechanic, MechanicView>(x)).ToList();

            return mechanics;
        }

        public MechanicView GetMechanic(int? id)
        {
            Mechanic v = db.Mechanics.Find(id);
            if (v == null)
            {
                return null;
            }
            MechanicView mechanic = mapper.Map<Mechanic, MechanicView>(v);
            return mechanic;

        }

        public void UpdateMechanic(MechanicView mechanics)
        {
            Mechanic mechanic = db.Mechanics.Find(mechanics.Id);
            mechanic.Name = mechanics.Name;
            mechanic.Email = mechanics.Email;
            mechanic.Phone = mechanics.Phone;
            mechanic.Make = mechanics.Make;
           
            db.Entry(mechanic).State = EntityState.Modified;
        }

        public void RemoveMechanic(int id)
        {
            Mechanic v = db.Mechanics.Find(id);
            db.Mechanics.Remove(v);
            db.SaveChanges();

        }

    }
}
