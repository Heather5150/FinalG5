using FinalG5.Data;
using FinalG5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalG5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HobbyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Hobby
        [HttpGet]
        public IActionResult GetHobbies(int? id)
        {
            if (id == null || id == 0)
                return Ok(_context.Hobbies.Take(5).ToList());

            var hobby = _context.Hobbies.Find(id);
            if (hobby == null) return NotFound();
            return Ok(hobby);
        }

        // POST: api/Hobby
        [HttpPost]
        public IActionResult CreateHobby([FromBody] Hobby hobby)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Hobbies.Add(hobby);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetHobbies), new { id = hobby.Id }, hobby);
        }

        // PUT: api/Hobby/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateHobby(int id, [FromBody] Hobby hobby)
        {
            if (id != hobby.Id) return BadRequest();

            var existingHobby = _context.Hobbies.Find(id);
            if (existingHobby == null) return NotFound();

            existingHobby.Name = hobby.Name;
            existingHobby.Description = hobby.Description;
            existingHobby.DifficultyLevel = hobby.DifficultyLevel;
            existingHobby.AverageTimeSpentPerWeek = hobby.AverageTimeSpentPerWeek;
            existingHobby.IsOutdoorActivity = hobby.IsOutdoorActivity;

            _context.Hobbies.Update(existingHobby);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Hobby/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteHobby(int id)
        {
            var hobby = _context.Hobbies.Find(id);
            if (hobby == null) return NotFound();

            _context.Hobbies.Remove(hobby);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
