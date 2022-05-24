using Microsoft.EntityFrameworkCore;
using WebProduct.Controllers;
using WebProduct.Data;
namespace WebProduct.Data
{
    public class ConsoleGame
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
