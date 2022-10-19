using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace minimal_ef;

public static class EndpointsClassWithTypedResults
{
    public static void MapWidget2Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget2").WithTags(nameof(Widget2));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Widget2.ToListAsync();
        })
        .WithName("GetAllWidget2s")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Widget2>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            return await db.Widget2.FindAsync(id)
                is Widget2 model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetWidget2ById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, Widget2 widget2, ApplicationDbContext db) =>
        {
            var foundModel = await db.Widget2.FindAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }
            
            db.Update(widget2);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateWidget2")
        .WithOpenApi();

        group.MapPost("/", async (Widget2 widget2, ApplicationDbContext db) =>
        {
            db.Widget2.Add(widget2);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Widget2/{widget2.ID}",widget2);
        })
        .WithName("CreateWidget2")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok<Widget2>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            if (await db.Widget2.FindAsync(id) is Widget2 widget2)
            {
                db.Widget2.Remove(widget2);
                await db.SaveChangesAsync();
                return TypedResults.Ok(widget2);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteWidget2")
        .WithOpenApi();
    }
    
	public static void MapWidget3Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget3").WithTags(nameof(Widget3));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Widget3.ToListAsync();
        })
        .WithName("GetAllWidget3s")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Widget3>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            return await db.Widget3.FindAsync(id)
                is Widget3 model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetWidget3ById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, Widget3 widget3, ApplicationDbContext db) =>
        {
            var foundModel = await db.Widget3.FindAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }
            
            db.Update(widget3);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateWidget3")
        .WithOpenApi();

        group.MapPost("/", async (Widget3 widget3, ApplicationDbContext db) =>
        {
            db.Widget3.Add(widget3);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Widget3/{widget3.ID}",widget3);
        })
        .WithName("CreateWidget3")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok<Widget3>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            if (await db.Widget3.FindAsync(id) is Widget3 widget3)
            {
                db.Widget3.Remove(widget3);
                await db.SaveChangesAsync();
                return TypedResults.Ok(widget3);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteWidget3")
        .WithOpenApi();
    }
}
