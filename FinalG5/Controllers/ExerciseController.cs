using FinalG5.Data;
using FinalG5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalG5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExerciseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/exercise
        [HttpGet]
        public IActionResult GetExercises(int? id)
        {
            if (id == null || id == 0)
                return Ok(_context.Exercises.Take(5).ToList());

            var exercise = _context.Exercises.Find(id);
            if (exercise == null) return NotFound();
            return Ok(exercise);
        }

        // POST: api/exercise
        [HttpPost]
        public IActionResult Createexercise([FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Exercises.Add(exercise);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetExercises), new { id = exercise.Id }, exercise);
        }

        // PUT: api/exercise/{id}
        [HttpPut("{id}")]
        public IActionResult Updateexercise(int id, [FromBody] Exercise exercise)
        {
            if (id != exercise.Id) return BadRequest();

            var existingexercise = _context.Exercises.Find(id);
            if (existingexercise == null) return NotFound();

            existingexercise.Name = exercise.Name;
            existingexercise.Description = exercise.Description;
            existingexercise.Repetitions = exercise.Repetitions;
            existingexercise.Sets = exercise.Sets;
            existingexercise.RequiresEquipment = exercise.RequiresEquipment;

            _context.Exercises.Update(existingexercise);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/exercise/{id}
        [HttpDelete("{id}")]
        public IActionResult Deleteexercise(int id)
        {
            var exercise = _context.Exercises.Find(id);
            if (exercise == null) return NotFound();

            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
