using EventSphere.DataAccess.Data;
using EventSphere.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    { 
        public IEventCategoryRepositorty eventCategoryRepositorty {  get; private set; }
        public IContectUsRepository contectUsRepository { get; private set; }

        private ApplicationDBContext _db;

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            eventCategoryRepositorty = new EventCategoryRepository(_db);
            contectUsRepository = new ContectUsRepository(_db);
        }

        public void save()
        {
            _db.SaveChanges();
        }



    }
}
