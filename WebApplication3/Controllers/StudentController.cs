using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Models;
using WebApplication3.Models.repositories;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        readonly IStudentRepository studentRepository;
        readonly ISchoolRepository schoolRepository;
        //injection de dépendance
        public StudentController(IStudentRepository scRepository, ISchoolRepository schoolRepository)
        {
            studentRepository = scRepository;
            this.schoolRepository = schoolRepository;
        }

        // GET: SchoolController
        public ActionResult Index()
        {
            var student = studentRepository.GetAll();
            return View(student);


        }

        // GET: SchoolController/Details/5

        public ActionResult Details(int id)
        {
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s)
        {
            try
            {
                studentRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student newstudent)
        {
            try
            {
                studentRepository.Edit(newstudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student ss)
        {
            try
            {
                studentRepository.Delete(ss);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string name, int? schoolid)
        {
            var result = studentRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = studentRepository.FindByName(name);
            else
            if (schoolid != null)
                result = studentRepository.GetStudentsBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }
    }
}
