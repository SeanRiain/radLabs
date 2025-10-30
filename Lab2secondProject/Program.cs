using Lab2secondProject;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdsDb>(opt => opt.UseInMemoryDatabase("AdList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/Ads", async (AdsDb db) =>
    await db.Advertisements.ToListAsync());

//app.MapGet("/todoitems/complete", async (AdsDb db) =>
   // await db.Advertisements.Where(t => t.Price).ToListAsync());

app.MapGet("/Ads/{id}", async (int id, AdsDb db) =>
    await db.Advertisements.FindAsync(id)
        is Ads ad
            ? Results.Ok(ad)
            : Results.NotFound());

app.MapPost("/Ads", async (Ads ad, AdsDb db) =>
{
    db.Advertisements.Add(ad);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{ad.ID}", ad);
});

app.MapPut("/Ads/{id}", async (int id, Ads inputAd, AdsDb db) =>
{
    var todo = await db.Advertisements.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Description = inputAd.Description;
    todo.Price = inputAd.Price;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Ads/{id}", async (int id, AdsDb db) =>
{
    if (await db.Advertisements.FindAsync(id) is Ads ad)
    {
        db.Advertisements.Remove(ad);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

// Search ads by seller
app.MapGet("/Ads/Seller/{sID}", async (int sID, AdsDb db) =>
    await db.Advertisements
            .Where(ad => ad.SellerID == sID)
            .ToListAsync());

// Search ads by category (ordered alphabetically by description)
app.MapGet("/Ads/Category/{cID}", async (int cID, AdsDb db) =>
    await db.Advertisements
            .Where(ad => ad.CategoryID == cID)
            .OrderBy(a => a.Description)
            .ToListAsync());

app.Run();