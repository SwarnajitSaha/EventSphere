using EventSphere.DataAccess.Data;
using EventSphere.DataAccess.Repository.IRepository;
using EventSphere.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.DataAccess.Repository
{
    public class EventCategoryRepository : Repository<EventCategory>, IEventCategoryRepositorty
    {
        private readonly ApplicationDBContext _db;
        public EventCategoryRepository(ApplicationDBContext db) : base(db) 
        {
            _db = db;
        }


        void IEventCategoryRepositorty.update(EventCategory obj)
        {
            _db.EventCategories.Update(obj);
        
        
        }
    }
}
