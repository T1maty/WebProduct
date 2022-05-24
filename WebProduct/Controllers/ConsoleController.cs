using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal.Data;
using WebProduct.Data;

namespace WebProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsoleController : ControllerBase
    {
        private readonly DataContext _context;

        public async Task<ActionResult<List<ConsoleGame>>> GetConsoleGames()
        {
            return Ok(await _context.ConsoleGames.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ConsoleGame>>> GetConsoleGame(int id)
        {
            var product = await _context.VideoGames.FindAsync(id);
            if (product == null)
                return NotFound("No product here. // Please enter name product");
            return Ok(product);
        }

        [HttpPost("CreateConsole")]
        public async Task<ActionResult<List<ConsoleGame>>> CreateConsoleGame(ConsoleGame product)
        {
            _context.ConsoleGames.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.VideoGames.ToListAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<ConsoleGame>>> UpdateConsoleGame(ConsoleGame game, int id)
        {
            var dbGame = await _context.ConsoleGames.FindAsync(id);
            if (dbGame == null)
                return NotFound("No console here.:/");

            dbGame.Id = game.Id;

            dbGame.Name = game.Name;

            dbGame.Price = game.Price;

            await _context.SaveChangesAsync();
            return Ok(await _context.VideoGames.ToListAsync());

        }

    }
}

