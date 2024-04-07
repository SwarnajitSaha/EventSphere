using EventSphere.DataAccess.Repository.IRepository;
using EventSphere.Models.Models;
using EventSphere.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EventSphere.Areas.EventProcess.Controllers
{
    [Area("EventProcess")]
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public HomeVM homeVM { get; set; }

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Home()
        {

            homeVM = new()
            {
                eventsList = _unitOfWork.eventCategoryRepositorty.GetAll(),
                ContectUS = new()
            };

            return View(homeVM);
        }

        [HttpPost]
        public IActionResult Home(HomeVM homeVM)
        {
            if(homeVM.ContectUS != null) 
            {
                _unitOfWork.contectUsRepository.Add(homeVM.ContectUS);
                _unitOfWork.save();

            }
            homeVM = new()
            {
                eventsList = _unitOfWork.eventCategoryRepositorty.GetAll(),
                ContectUS = new()
            };
            return View(homeVM);
        }
    }
}
