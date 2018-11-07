using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Models
{
    public class Demo2Context : DbContext
    {
        public Demo2Context (DbContextOptions<Demo2Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student()
                {
                    RollNumber = "A001",
                    FirstName = "Giang",
                    LastName = "Tinh",
                    Email = "tinhgiang9898@gmail.com",
                },
                new Student()
                {
                    RollNumber = "A002",
                    FirstName = "Huong",
                    LastName = "Ly",
                    Email = "ly@gmail.com",
                }, new Student()
                {
                    RollNumber = "A003",
                    FirstName = "Thanh",
                    LastName = "Tung",
                    Email = "thanhtung@gmail.com",
                });

            modelBuilder.Entity<Mark>().HasData(new Mark()
                {
                    ID = 1,
                    SubjectName = "Java",
                    StudentRollNumber = "A001",
                    SubjectMark = 20,
                },
                new Mark()
                {
                    ID = 2,
                    SubjectName = "C#",
                    StudentRollNumber = "A002",
                    SubjectMark = 20,
                },
                new Mark()
                {
                    ID = 3,
                    SubjectName = "PHP",
                    StudentRollNumber = "A003",
                    SubjectMark = 20,
                });
        }
        public DbSet<Demo2.Models.Student> Student { get; set; }
        public DbSet<Demo2.Models.Mark> Marks { get; set; }

    }
}
