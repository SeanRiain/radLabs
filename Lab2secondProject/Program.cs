using Lab2secondProject;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdsDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/Ads", async (AdsDb db) =>
    await db.Advertisements.ToListAsync());

//app.MapGet("/todoitems/complete", async (AdsDb db) =>
   // await db.Advertisements.Where(t => t.Price).ToListAsync());

app.MapGet("/Ads/{id}", async (int id, AdsDb db) =>
    await db.Advertisements.FindAsync(id)
        is Ads todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/Ads", async (Ads todo, AdsDb db) =>
{
    db.Advertisements.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/Ads/{id}", async (int id, Ads inputTodo, AdsDb db) =>
{
    var todo = await db.Advertisements.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Description = inputTodo.Description;
    todo.Price = inputTodo.Price;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Ads/{id}", async (int id, AdsDb db) =>
{
    if (await db.Advertisements.FindAsync(id) is Ads todo)
    {
        db.Advertisements.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();