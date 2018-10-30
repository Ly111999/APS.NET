using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Demo1.Controllers
{
    public class StudentController : Controller
    {
        private readonly MyDbContext _context;

        public StudentController(MyDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            ViewData["Name"] = "Hello";
            return View(_context.StudentItem.ToList());
        }

        [Route("/MyListStudent/Create")]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Store(Student student)
        {
            if (!_context.StudentItem.Any())
            {
                _context.StudentItem.Add(student);
                _context.SaveChanges();
                TempData["message"] = "Created success !!!";
            }
            return Redirect("Index");
        }

        public IActionResult Edit(long id)
        {
            var student = _context.StudentItem.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Update(Student student)
        {
            var exisStudent = _context.StudentItem.Find(student.Id);
            if (exisStudent == null)
            {
                return NotFound();
            }
            exisStudent.RollNumber = student.RollNumber;
            exisStudent.Name = student.Name;
            _context.StudentItem.Update(exisStudent);
            _context.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Delete(long id)
        {
            var exisStudent = _context.StudentItem.Find(id);
            if (exisStudent == null)
            {
                return NotFound();
            }

            _context.StudentItem.Remove(exisStudent);
            _context.SaveChanges();
            return Redirect("Index");
        }
    }
}