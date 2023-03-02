using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.repositories;

namespace WebApplication3.Controllers
{
    public class SchoolController : Controller
    {
        readonly ISchoolRepository schoolRepository;
        //injection de dépendance
        public SchoolController(ISchoolRepository scRepository)
        {
            schoolRepository = scRepository;
        }

        // GET: SchoolController
        public ActionResult Index()
        {
            var schools = schoolRepository.GetAll();
            return View(schools);


        }

        // GET: SchoolController/Details/5

        public ActionResult Details(int id)
        {
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School s)
        {
            try
            {
                schoolRepository.Add(s);
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
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, School newSchool)
        {
            try
            {
                schoolRepository.Edit( newSchool);
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
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, School s)
        {
            try
            {
                schoolRepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
