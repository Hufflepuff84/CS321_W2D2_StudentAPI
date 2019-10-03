using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS321_W2D2_StudentAPI.Services;
using CS321_W2D2_StudentAPI.Models;

namespace CS321_W2D2_StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;
        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            // return new string[] { "value1", "value2" };
            return Ok(_studentsService.GetAll());
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //return "value";
            var student = _studentsService.Get(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Student newStudent)
        {
            try
            {
                _studentsService.Add(newStudent);
                return CreatedAtAction("Get", new { id = newStudent.Id }, newStudent);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddStudent", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student updatedStudent)
        {
            var student = _studentsService.Update(updatedStudent);
            if (student == null) return NotFound();
            return Ok(updatedStudent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _studentsService.Get(id);
            if (student == null) return NotFound();
            _studentsService.Remove(student);
            return NoContent();
        }
    }
}
