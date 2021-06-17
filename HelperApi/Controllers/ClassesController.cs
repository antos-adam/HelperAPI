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
    public class ClassesController : ControllerBase
    {
        private readonly HelperDbContext _context;

        public ClassesController(HelperDbContext context)
        {
            _context = context;
        }

        // GET: api/Classes
        [HttpGet]
        public IActionResult GetClasses()
        {
            return Ok(_context.Classes);
        }

        // GET: api/Classes/P3
        [HttpGet("{name}")]
        public IActionResult GetClass(string name)
        {
            var helperClass = _context.Classes.Find(name);

            if (helperClass == null)
            {
                return NotFound();
            }

            return Ok(helperClass);
        }

        // GET: api/Classes/P3/Students
        [HttpGet("{name}/Students")]
        public IActionResult GetStudents(string name)
        {
            /*var helperClass = _context.Classes.Find(name);

            if (helperClass == null)
            {
                return NotFound();
            }*/
            return Ok(_context.Students.Where(s => s.ClassName == name));
        }

        // PUT: api/Classes/P3
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{name}")]
        public IActionResult PutClass(string name, ClassViewModel _class)
        {
            var helperClass = _context.Classes.Find(name);
            if (helperClass != null)
            {
                helperClass.Name = _class.Name;
                _context.Entry(helperClass).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        // POST: api/Classes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostClass(ClassViewModel _class)
        {
            var helperClass = new Class() { Name = _class.Name };
            _context.Classes.Add(helperClass);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClassExists(helperClass.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClass", new { name = helperClass.Name }, helperClass);
        }
        
        // DELETE: api/Classes/P3
        [HttpDelete("{name}")]
        public IActionResult DeleteClass(string name)
        {
            var helperClass = _context.Classes.Find(name);
            if (helperClass == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(helperClass);
            _context.SaveChanges();

            return NoContent();
        }
        
        private bool ClassExists(string id)
        {
            return _context.Classes.Any(e => e.Name == id);
        }

        public class ClassViewModel
        {
            public string Name { get; set; }
        }
    }
}
