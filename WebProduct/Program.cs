using Microsoft.EntityFrameworkCore;
using Minimal.Data;
using WebProduct.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("videogames"));

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("consolegames"));

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


app.MapGet("consolegame", async (DataContext context) => await context.ConsoleGames.ToListAsync());

app.MapGet("consolegame/{id}", async  (DataContext context, int id) =>

await context.ConsoleGames.FindAsync(id) is ConsoleGame game ?

Results.Ok(game) :
Results.NotFound("No Console here. :/" ));

app.MapPost("/videogame", async (DataContext context, ConsoleGame game) =>
{
    context.ConsoleGames.Add(game);
    await context.SaveChangesAsync();
    return Results.Ok(await context.ConsoleGames.ToListAsync());
});


app.Run();