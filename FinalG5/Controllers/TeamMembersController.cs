using FinalG5.Data;
using FinalG5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalG5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TeamMember
        [HttpGet]
        public IActionResult GetTeamMembers(int? id)
        {
            if (id == null || id == 0)
                return Ok(_context.TeamMembers.Take(5).ToList());

            var teamMember = _context.TeamMembers.Find(id);
            if (teamMember == null) return NotFound();
            return Ok(teamMember);
        }

        // POST: api/TeamMember
        [HttpPost]
        public IActionResult CreateTeamMember([FromBody] TeamMember teamMember)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.TeamMembers.Add(teamMember);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTeamMembers), new { id = teamMember.Id }, teamMember);
        }

        // PUT: api/TeamMember/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeamMember(int id, [FromBody] TeamMember teamMember)
        {
            if (id != teamMember.Id) return BadRequest();

            var existingMember = _context.TeamMembers.Find(id);
            if (existingMember == null) return NotFound();

            existingMember.FullName = teamMember.FullName;
            existingMember.Birthdate = teamMember.Birthdate;
            existingMember.CollegeProgram = teamMember.CollegeProgram;
            existingMember.YearInProgram = teamMember.YearInProgram;

            _context.TeamMembers.Update(existingMember);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/TeamMember/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTeamMember(int id)
        {
            var teamMember = _context.TeamMembers.Find(id);
            if (teamMember == null) return NotFound();

            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
