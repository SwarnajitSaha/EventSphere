using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEventCategoryRepositorty eventCategoryRepositorty { get; }
        IContectUsRepository contectUsRepository { get; }
        void save();
    }
}
