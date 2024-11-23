using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab6.Data;
using Lab6.Models;

namespace Lab6.Controllers
{
    [Route("api/[controller]")] //host.com/api/Student/1
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // returned when we return list of Students successfully
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // returned when there is an error in processing the request
        [ProducesResponseType(StatusCodes.Status404NotFound)]// if list is not found
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]//Requested resource needs authentication
        [ProducesResponseType(StatusCodes.Status403Forbidden)] //return when client does not have premission to access the resource
        [ProducesResponseType(StatusCodes.Status302Found)] //return if the resource has been temporarily moved to different uri example can be migration to different database or virtual machine
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // returned when we return list of Students successfully
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // returned when there is an error in processing the request
        [ProducesResponseType(StatusCodes.Status404NotFound)]// if list is not found
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]//Requested resource needs authentication
        [ProducesResponseType(StatusCodes.Status403Forbidden)] //return when client does not have premission to access the resource

        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Standard 200 stauts code for PUT. return if student is successfully updated 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //Return if bad request is sent form client to server. student id id not found
        [ProducesResponseType(StatusCodes.Status404NotFound)] //return if the server could not student or save it to database. This is server situation in 404 💔


        public async Task<ActionResult<Student>> PutStudent(Guid id, Student student)
        {
            if (id != student.ID)
            {
                return BadRequest();
            }

            

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(student);
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)] // returned when we return list of Students successfully
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // returned when there is an error in processing the request
        [ProducesResponseType(StatusCodes.Status404NotFound)]// if list is not found
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]//Requested resource needs authentication
        [ProducesResponseType(StatusCodes.Status403Forbidden)] //return when client does not have premission to access the resource
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.ID }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // returned when we return list of Students successfully
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // returned when there is an error in processing the request
        [ProducesResponseType(StatusCodes.Status404NotFound)]// if list is not found
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]//Requested resource needs authentication
        [ProducesResponseType(StatusCodes.Status403Forbidden)] //return when client does not have premission to access the resource
        [ProducesResponseType(StatusCodes.Status204NoContent)]// return when the server has successfully processed the request but no content is returned or no content in response body
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(Guid id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
