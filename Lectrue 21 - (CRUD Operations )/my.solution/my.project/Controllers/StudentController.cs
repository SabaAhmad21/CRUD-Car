using Microsoft.AspNetCore.Mvc;
using my.project.Infrastructure.Implementation;
using my.project.Infrastructure.Interfaces;
using my.project.ViewModels;

namespace my.project.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Students")]
        public IActionResult Students()
        {
            //Read Data from database and send it to the view.

            return View(_studentRepository.StudentGetAll());
        }
        public IActionResult StudentCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentCreate(StudentCrateVM model)
        {
            if (ModelState.IsValid)
            {
                if (_studentRepository.StudentCreate(model))
                {
                    ModelState.AddModelError("", "Student Created Successfully!");
                }
                else
                {
                    ModelState.AddModelError("", "Something Went Wrong!");
                }
                return View();
            }
            return View();
        }
        public IActionResult IsRoleNumberExist(string RoleNumber)
        {
            return Json(!_studentRepository.IsRoleNumberExist(RoleNumber)); 
        }
        public IActionResult StudentDelete(int id)
        {
            _studentRepository.StudentDelete(id);
            return RedirectToAction("Students", new { Controller = "Student" });
        }
        public IActionResult StudentUpdate(int id)
        {
            return View(_studentRepository.StudentGetById(id));
        }
        [HttpPost]
        public IActionResult StudentUpdate(StudentUpdateM model)
        {
            _studentRepository.StudentUpdate(model);
            return RedirectToAction("Students", new { Controller = "Student" });
        }
    }
}
