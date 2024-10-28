using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HotelListing.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> Students = new List<Student>
        {
            new Student 
            { 
                studentId = 1, 
                firstName = "Alice", 
                lastName = "Turner",
                studentAge = 20,
                course = "Computer Science"
            },

            new Student 
            { 
                studentId = 2, 
                firstName = "Bob",
                lastName = "Marley",
                studentAge = 22, 
                course = "Mathematics" 
            },

            new Student 
            { 
                studentId = 3, 
                firstName = "Charlie", 
                lastName = "Conway", 
                studentAge = 21, 
                course = "Physics" 
            }
        };

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }


        // HTTP GET 
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return Students;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = Students.FirstOrDefault(s => s.studentId == id);

            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // HTTP POST 
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {

            student.studentId = Students.Max(s => s.studentId) + 1; // Simple ID assignment
            Students.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.studentId }, student);

        }

        // HTTP PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            var existingStudent = Students.FirstOrDefault(s => s.studentId == id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.firstName = student.firstName;
            existingStudent.studentAge = student.studentAge;
            existingStudent.course = student.course;
            return NoContent();
        }

        // HTTP DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = Students.FirstOrDefault(s => s.studentId == id);
            if (student == null)
            {
                return NotFound();
            }
            Students.Remove(student);
            return NoContent();
        }
    }
}
