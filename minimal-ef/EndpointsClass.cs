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
}
