using EventSphere.DataAccess.Repository.IRepository;
using EventSphere.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSphere.Areas.Company.Controllers
{
    [Area("Company")]
    public class EventOperation : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventOperation(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult EventList()
        {
            List<EventCategory> categories = _unitOfWork.eventCategoryRepositorty.GetAll().ToList();
            return View(categories);
        }
        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(EventCategory obj, IFormFile? file_1)
        {
            if (ModelState.IsValid)
            {
                string rootPath = _webHostEnvironment.WebRootPath;

                if (file_1!=null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file_1.FileName);
                    string filePath = Path.Combine(rootPath, @"image\eventProfileImage\");

                    using (var filestream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                    {
                        file_1.CopyTo(filestream);
                    }

                    obj.ProfileImage=@"\image\eventProfileImage\" + fileName;
                }

                _unitOfWork.eventCategoryRepositorty.Add(obj);
                _unitOfWork.save();
            }
            return RedirectToAction("EventList");
        }

        public IActionResult Edit(int? id)
        {
            var events = _unitOfWork.eventCategoryRepositorty.Get(u => u.Id==id);
            return View(events);
        }

        [HttpPost]
        public IActionResult Edit(EventCategory obj, IFormFile? image)
        {
            if (obj!=null)
            {
                if (image==null)
                {
                    _unitOfWork.eventCategoryRepositorty.update(obj);
                }
                else
                {

                    string rootPath = _webHostEnvironment.WebRootPath;
                    if (obj.ProfileImage!=null)
                    {//delet the previous image
                        var oldImagePath = Path.Combine(rootPath, obj.ProfileImage.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }



                    //upload the new image
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    string filePath = Path.Combine(rootPath, @"image\eventProfileImage");

                    using (var filestream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                    {
                        image.CopyTo(filestream);
                    }

                    obj.ProfileImage=@"image\eventProfileImage\" + fileName;
                    
                    _unitOfWork.eventCategoryRepositorty.update(obj);
                }


            }
            _unitOfWork.save();
            return RedirectToAction("EventList");


        }

        public ActionResult DeleteEvent(int? id)
        {
            if (id != null)
            {
                var events = _unitOfWork.eventCategoryRepositorty.Get(u => u.Id == id);
                if (events != null)
                {
                    _unitOfWork.eventCategoryRepositorty.Remove(events);
                    _unitOfWork.save();
                    return RedirectToAction("EventList");
                }

            }
            return NotFound();

        }

        public IActionResult Messages()
        {
            IEnumerable<ContectUS> message = _unitOfWork.contectUsRepository.GetAll(u => u.Status=="unread");
            return View(message);
        }
        public IActionResult Read(int id)
        {
            ContectUS contect = _unitOfWork.contectUsRepository.Get(u => u.Id == id);
            if (contect != null)
            {
                contect.Status = "read";
                _unitOfWork.contectUsRepository.update(contect);
                _unitOfWork.save(); 
            }
            return RedirectToAction("Messages");
        }

        public IActionResult Delete(int id)
        {
            ContectUS contect = _unitOfWork.contectUsRepository.Get(u => u.Id == id);
            _unitOfWork.contectUsRepository.Remove(contect);
            _unitOfWork.save();
            return RedirectToAction("Messages");

        }
    }
}
