namespace minimal_no_ef;

public static class EndpointsClass
{
    public static void MapWidgetEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget");

        group.MapGet("/", () =>
        {
            return new [] { new Widget() };
        })
        .WithName("GetAllWidgets");

        group.MapGet("/{id}", (int id) =>
        {
            //return new Widget { ID = id };
        })
        .WithName("GetWidgetById");

        group.MapPut("/{id}", (int id, Widget input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateWidget");

        group.MapPost("/", (Widget model) =>
        {
            //return Results.Created($"/Widgets/{model.ID}", model);
        })
        .WithName("CreateWidget");

        group.MapDelete("/{id}", (int id) =>
        {
            //return Results.Ok(new Widget { ID = id });
        })
        .WithName("DeleteWidget");  
    }
}
