using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal.Data;
using WebProduct.Data;

namespace WebProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGame(int id)
        {
            var product = await _context.VideoGames.FindAsync(id);
            if (product == null)
                return NotFound("No product here. // Please enter name product");
            return Ok(product);
        }
        [HttpPost("CreateGame")]
        public async Task<ActionResult<List<VideoGame>>> CreateVideoGame(VideoGame product)
        {
            _context.VideoGames.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.VideoGames.ToListAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<VideoGame>>> UpdateVideoGame(VideoGame game, int id)
        {
            var dbGame = await _context.VideoGames.FindAsync(id);
            if (dbGame == null)
                return NotFound("No game here.:/");

            dbGame.Name = game.Name;
            dbGame.Developer = game.Developer;
            dbGame.Release = game.Release;
            await _context.SaveChangesAsync();
            return Ok(await _context.VideoGames.ToListAsync());

        }

       

    }

}
