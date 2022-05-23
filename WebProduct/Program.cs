using Microsoft.EntityFrameworkCore;
using Minimal.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("videogames"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/videogame", async (DataContext context) => await context.VideoGames.ToListAsync());

app.MapGet("/videogame/{id}", async (DataContext context, int id) =>

 await context.VideoGames.FindAsync(id) is VideoGame game ?

 Results.Ok(game) :

 Results.NotFound("No game here. :/"));

app.MapPost("/videogame", async (DataContext context, VideoGame game) =>
{
    context.VideoGames.Add(game);
    await context.SaveChangesAsync();
    return Results.Ok(await context.VideoGames.ToListAsync());
});
app.Run();