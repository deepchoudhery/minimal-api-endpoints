using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace minimal_ef;

public static class EndpointsClassWithoutTypedResults
{
    public static void MapWidget4Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget4").WithTags(nameof(Widget4));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Widget4.ToListAsync();
        })
        .WithName("GetAllWidget4s")
        .WithOpenApi()
        .Produces<List<Widget4>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async  (int id, ApplicationDbContext db) =>
        {
            return await db.Widget4.FindAsync(id)
                is Widget4 model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetWidget4ById")
        .WithOpenApi()
        .Produces<Widget4>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async  (int id, Widget4 widget4, ApplicationDbContext db) =>
        {
            var foundModel = await db.Widget4.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(widget4);
            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateWidget4")
        .WithOpenApi()
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (Widget4 widget4, ApplicationDbContext db) =>
        {
            db.Widget4.Add(widget4);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Widget4/{widget4.ID}",widget4);
        })
        .WithName("CreateWidget4")
        .WithOpenApi()
        .Produces<Widget4>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async  (int id, ApplicationDbContext db) =>
        {
            if (await db.Widget4.FindAsync(id) is Widget4 widget4)
            {
                db.Widget4.Remove(widget4);
                await db.SaveChangesAsync();
                return Results.Ok(widget4);
            }

            return Results.NotFound();
        })
        .WithName("DeleteWidget4")
        .WithOpenApi()
        .Produces<Widget4>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
    
	public static void MapWidget5Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget5").WithTags(nameof(Widget5));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Widget5.ToListAsync();
        })
        .WithName("GetAllWidget5s")
        .WithOpenApi()
        .Produces<List<Widget5>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async Task<Results<Ok<Widget5>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            return await db.Widget5.FindAsync(id)
                is Widget5 model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetWidget5ById")
        .WithOpenApi()
        .Produces<Widget5>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, Widget5 widget5, ApplicationDbContext db) =>
        {
            var foundModel = await db.Widget5.FindAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }
            
            db.Update(widget5);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateWidget5")
        .WithOpenApi()
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (Widget5 widget5, ApplicationDbContext db) =>
        {
            db.Widget5.Add(widget5);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Widget5/{widget5.ID}",widget5);
        })
        .WithName("CreateWidget5")
        .WithOpenApi()
        .Produces<Widget5>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async Task<Results<Ok<Widget5>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            if (await db.Widget5.FindAsync(id) is Widget5 widget5)
            {
                db.Widget5.Remove(widget5);
                await db.SaveChangesAsync();
                return TypedResults.Ok(widget5);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteWidget5")
        .WithOpenApi()
        .Produces<Widget5>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
