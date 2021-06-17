using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelperApi.Models;

namespace HelperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly HelperDbContext _context;

        public StudentsController(HelperDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_context.Students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, StudentViewModel _student)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                student.Name = _student.Name;
                student.Surname = _student.Surname;
                student.ClassName = _student.ClassName;
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostStudent(StudentViewModel _student)
        {
            var student = new Student()
            {
                Name = _student.Name,
                Surname = _student.Surname,
                ClassName = _student.ClassName
            };
            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }
        public class StudentViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string ClassName { get; set; }
        }
    }
}
