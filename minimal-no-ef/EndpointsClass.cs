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
	public static void MapWidget6Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget6");

        group.MapGet("/", () =>
        {
            return new [] { new Widget6() };
        })
        .WithName("GetAllWidget6s")
        .Produces<Widget6[]>(StatusCodes.Status200OK);
        
        group.MapGet("/{id}", (int id) =>
        {
            //return new Widget6 { ID = id };
        })
        .WithName("GetWidget6ById")
        .Produces<Widget6>(StatusCodes.Status200OK);

        group.MapPut("/{id}", (int id, Widget6 input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateWidget6")
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", (Widget6 model) =>
        {
            //return TypedResults.Created($"/Widget6s/{model.ID}", model);
        })
        .WithName("CreateWidget6")
        .Produces<Widget6>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Widget6 { ID = id });
        })
        .WithName("DeleteWidget6")
        .Produces<Widget6>(StatusCodes.Status200OK);  
    }
}
