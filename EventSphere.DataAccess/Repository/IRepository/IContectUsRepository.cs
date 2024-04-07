using EventSphere.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.DataAccess.Repository.IRepository
{
    public interface IContectUsRepository : IRepository<ContectUS>
    {
        void update(ContectUS contectUS);
    }
}
