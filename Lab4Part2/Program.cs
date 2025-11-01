using Lab4Part2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<AdsDb>(opt => opt.UseInMemoryDatabase("AdList"));
var connectionString = builder.Configuration.GetConnectionString("ads") ?? "Data Source=ads.db";
builder.Services.AddSqlite<AdsDB>(connectionString);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

app.MapGet("/Ads", async (AdsDB db) =>
    await db.Advertisements.ToListAsync());

//app.MapGet("/todoitems/complete", async (AdsDb db) =>
   // await db.Advertisements.Where(t => t.Price).ToListAsync());

app.MapGet("/Ads/{id}", async (int id, AdsDB db) =>
    await db.Advertisements.FindAsync(id)
        is Ads ad
            ? Results.Ok(ad)
            : Results.NotFound());

app.MapPost("/Ads", async (Ads ad, AdsDB db) =>
{
    db.Advertisements.Add(ad);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{ad.ID}", ad);
});

app.MapPut("/Ads/{id}", async (int id, Ads inputAd, AdsDB db) =>
{
    var todo = await db.Advertisements.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Description = inputAd.Description;
    todo.Price = inputAd.Price;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Ads/{id}", async (int id, AdsDB db) =>
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
app.MapGet("/Ads/Seller/{sID}", async (int sID, AdsDB db) =>
    await db.Advertisements
            .Where(ad => ad.SellerID == sID)
            .ToListAsync());

// Search ads by category (ordered alphabetically by description)
app.MapGet("/Ads/Category/{cID}", async (int cID, AdsDB db) =>
    await db.Advertisements
            .Where(ad => ad.CategoryID == cID)
            .OrderBy(a => a.Description)
            .ToListAsync());

app.Run();