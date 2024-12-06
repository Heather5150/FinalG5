using FinalG5.Data;
using FinalG5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalG5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoardGamesController(AppDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult GetBoardGames(int? id)
        {
            if (id == null || id == 0)
                return Ok(_context.BoardGames.Take(5).ToList());

            var BoardGames = _context.BoardGames.Find(id);
            if (BoardGames == null) return NotFound();
            return Ok(BoardGames);
        }

        [HttpPost]
        public IActionResult CreateBoardGames([FromBody] BoardGames BoardGames)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.BoardGames.Add(BoardGames);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBoardGames), new { id = BoardGames.Id }, BoardGames);
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateBoardGames(int id, [FromBody]
        BoardGames BoardGames)
        {
            if (id != BoardGames.Id) return BadRequest();

            var existingBoardGames = _context.BoardGames.Find(id);
            if (existingBoardGames == null) return NotFound();

            existingBoardGames.Name = BoardGames.Name;
            existingBoardGames.Description = BoardGames.Description;
            existingBoardGames.DifficultyLevel = BoardGames.DifficultyLevel;
            existingBoardGames.AveragePlayTime = BoardGames.AveragePlayTime;

            _context.BoardGames.Update(existingBoardGames);
            _context.SaveChanges();

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteBoardGames(int id)
        {
            var BoardGames = _context.BoardGames.Find(id);
            if (BoardGames == null) return NotFound();

            _context.BoardGames.Remove(BoardGames);
            _context.SaveChanges();
            return NoContent();
        }
    }
}