using Microsoft.EntityFrameworkCore;
using WebProduct.Controllers;

namespace Minimal.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
    }
}
