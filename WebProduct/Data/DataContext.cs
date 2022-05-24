using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProduct.Controllers;
using WebProduct.Data;

namespace Minimal.Data
{
    public class DataContext : DbContext
    {
        private readonly object _context;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<ConsoleGame> ConsoleGames => Set<ConsoleGame>();

        
    }
}
