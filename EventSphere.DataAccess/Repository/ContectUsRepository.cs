using EventSphere.DataAccess.Data;
using EventSphere.DataAccess.Repository.IRepository;
using EventSphere.Models.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.DataAccess.Repository
{
    public class ContectUsRepository : Repository<ContectUS>, IContectUsRepository
    {
        private readonly ApplicationDBContext _db;

        public ContectUsRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void update(ContectUS contectUS)
        {
            _db.ContectUs.Update(contectUS);
        }
    }
}
