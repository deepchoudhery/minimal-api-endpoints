using Microsoft.EntityFrameworkCore;
namespace minimal_ef;

public static class EndpointsClass
{
    public static void MapWidgetEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget");

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Widget.ToListAsync();
        })
        .WithName("GetAllWidgets");

        group.MapGet("/{id}", async  (int id, ApplicationDbContext db) =>
        {
            return await db.Widget.FindAsync(id)
                is Widget model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetWidgetById");

        group.MapPut("/{id}", async  (int id, Widget widget, ApplicationDbContext db) =>
        {
            var foundModel = await db.Widget.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(widget);
            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateWidget");

        group.MapPost("/", async (Widget widget, ApplicationDbContext db) =>
        {
            db.Widget.Add(widget);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Widget/{widget.ID}",widget);
        })
        .WithName("CreateWidget");

        group.MapDelete("/{id}", async  (int id, ApplicationDbContext db) =>
        {
            if (await db.Widget.FindAsync(id) is Widget widget)
            {
                db.Widget.Remove(widget);
                await db.SaveChangesAsync();
                return Results.Ok(widget);
            }

            return Results.NotFound();
        })
        .WithName("DeleteWidget");
    }
	public static void MapWidget6Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget6");

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Widget6.ToListAsync();
        })
        .WithName("GetAllWidget6s")
        .Produces<List<Widget6>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async  (int id, ApplicationDbContext db) =>
        {
            return await db.Widget6.FindAsync(id)
                is Widget6 model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetWidget6ById")
        .Produces<Widget6>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async  (int id, Widget6 widget6, ApplicationDbContext db) =>
        {
            var foundModel = await db.Widget6.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(widget6);
            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateWidget6")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (Widget6 widget6, ApplicationDbContext db) =>
        {
            db.Widget6.Add(widget6);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Widget6/{widget6.ID}",widget6);
        })
        .WithName("CreateWidget6")
        .Produces<Widget6>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async  (int id, ApplicationDbContext db) =>
        {
            if (await db.Widget6.FindAsync(id) is Widget6 widget6)
            {
                db.Widget6.Remove(widget6);
                await db.SaveChangesAsync();
                return Results.Ok(widget6);
            }

            return Results.NotFound();
        })
        .WithName("DeleteWidget6")
        .Produces<Widget6>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
