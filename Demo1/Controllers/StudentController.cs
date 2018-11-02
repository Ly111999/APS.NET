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
            //if (_context.StudentItem.Count() <= 0)
            //{
                _context.StudentItem.Add(student);
                _context.SaveChanges();
                TempData["message"] = "Created success !!!";
            //}
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
            var existStudent = _context.StudentItem.Find(student.Id);
            if (existStudent == null)
            {
                return NotFound();
            }
            existStudent.RollNumber = student.RollNumber;
            existStudent.Name = student.Name;
            _context.StudentItem.Update(existStudent);
            _context.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Delete(long id)
        {
            var existStudent = _context.StudentItem.Find(id);
            if (existStudent == null)
            {
                return NotFound();
            }

            _context.StudentItem.Remove(existStudent);
            _context.SaveChanges();
            return Redirect("Index");
        }
    }
}