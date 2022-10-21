using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace minimal_no_ef;

public static class EndpointsClassWithoutTypedResults
{
    public static void MapWidget4Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget4").WithTags(nameof(Widget4));

        group.MapGet("/", () =>
        {
            return new [] { new Widget4() };
        })
        .WithName("GetAllWidget4s")
        .WithOpenApi()
        .Produces<Widget4[]>(StatusCodes.Status200OK);
        
        group.MapGet("/{id}", (int id) =>
        {
            //return new Widget4 { ID = id };
        })
        .WithName("GetWidget4ById")
        .WithOpenApi()
        .Produces<Widget4>(StatusCodes.Status200OK);

        group.MapPut("/{id}", (int id, Widget4 input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateWidget4")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", (Widget4 model) =>
        {
            //return TypedResults.Created($"/Widget4s/{model.ID}", model);
        })
        .WithName("CreateWidget4")
        .WithOpenApi()
        .Produces<Widget4>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Widget4 { ID = id });
        })
        .WithName("DeleteWidget4")
        .WithOpenApi()
        .Produces<Widget4>(StatusCodes.Status200OK);  
    }
	public static void MapWidget5Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget5").WithTags(nameof(Widget5));

        group.MapGet("/", () =>
        {
            return new [] { new Widget5() };
        })
        .WithName("GetAllWidget5s")
        .WithOpenApi()
        .Produces<Widget5[]>(StatusCodes.Status200OK);
        
        group.MapGet("/{id}", (int id) =>
        {
            //return new Widget5 { ID = id };
        })
        .WithName("GetWidget5ById")
        .WithOpenApi()
        .Produces<Widget5>(StatusCodes.Status200OK);

        group.MapPut("/{id}", (int id, Widget5 input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateWidget5")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", (Widget5 model) =>
        {
            //return TypedResults.Created($"/Widget5s/{model.ID}", model);
        })
        .WithName("CreateWidget5")
        .WithOpenApi()
        .Produces<Widget5>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Widget5 { ID = id });
        })
        .WithName("DeleteWidget5")
        .WithOpenApi()
        .Produces<Widget5>(StatusCodes.Status200OK);  
    }
}
