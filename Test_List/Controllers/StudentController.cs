using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Cryptography.X509Certificates;
using Test_List.DAL;
using Test_List.Models;
using Test_List.Models.Entities;

namespace Test_List.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDBcontext _context;
        public StudentController(StudentDBcontext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            var students = _context.Students.ToList();


            if (students != null)
            {

                foreach (var student in students)
                {
                    var StudentViewModel = new StudentViewModel()
                    {
                        Id = student.Id,
                        Name = student.FirstName,
                        LastName = student.LastName,
                        DateofRegister = student.DateofRegister,
                        Email = student.Email,
                        Units = student.Units,
                    };
                    studentList.Add(StudentViewModel);
                }
                return View(studentList);
            }

            return View(studentList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel studentData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Student()
                    {
                        FirstName = studentData.Name,
                        LastName = studentData.LastName,
                        DateofRegister = studentData.DateofRegister,
                        Email = studentData.Email,
                        Units = studentData.Units

                    };
                    _context.Students.Add(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Enrolled Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Information is not Valid.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();

            }

        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(x => x.Id == id);
                if (student != null)
                {
                    var studentView = new StudentViewModel()
                    {
                        Id = student.Id,
                        Name = student.FirstName,
                        LastName = student.LastName,
                        DateofRegister = student.DateofRegister,
                        Email = student.Email,
                        Units = student.Units
                    };
                    return View(studentView);
                }
                else
                {
                    TempData["errorMessage"] = $"Student ID cannot find.: {id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]

        public IActionResult Edit(StudentViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Student()
                    {
                        Id = model.Id,
                        FirstName = model.Name,
                        LastName = model.LastName,
                        DateofRegister = model.DateofRegister,
                        Email = model.Email,
                        Units = model.Units

                    };

                    _context.Students.Update(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Update is successful";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Invalid Information";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        public IActionResult Delete(int id)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(x => x.Id == id);
                if (student != null)
                {
                    var studentView = new StudentViewModel()
                    {
                        Id = student.Id,
                        Name = student.FirstName,
                        LastName = student.LastName,
                        DateofRegister = student.DateofRegister,
                        Email = student.Email,
                        Units = student.Units
                    };
                    return View(studentView);
                }
                else
                {
                    TempData["errorMessage"] = $"Student ID cannot find.: {id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
        [HttpPost]

        public IActionResult Delete(StudentViewModel model)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(x => x.Id == model.Id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Information Deletion is success";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Student ID cannot find.: {model.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
           
           
        }
    }
  }
    

