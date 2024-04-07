using EventSphere.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.DataAccess.Repository.IRepository
{
    public interface IEventCategoryRepositorty : IRepository<EventCategory>
    {
        void update(EventCategory obj);
    }
}
