using EventSphere.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.Models.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<EventCategory> eventsList { get; set; }
        public ContectUS ContectUS { get; set; }
    }
}
