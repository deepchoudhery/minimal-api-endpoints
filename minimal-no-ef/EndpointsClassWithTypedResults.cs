using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace minimal_no_ef;

public static class EndpointsClassWithTypedResults
{
    public static void MapWidget2Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget2").WithTags(nameof(Widget2));

        group.MapGet("/", () =>
        {
            return new [] { new Widget2() };
        })
        .WithName("GetAllWidget2s")
        .WithOpenApi();
        
        group.MapGet("/{id}", (int id) =>
        {
            //return new Widget2 { ID = id };
        })
        .WithName("GetWidget2ById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Widget2 input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateWidget2")
        .WithOpenApi();

        group.MapPost("/", (Widget2 model) =>
        {
            //return Results.Created($"/Widget2s/{model.ID}", model);
        })
        .WithName("CreateWidget2")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return Results.Ok(new Widget2 { ID = id });
        })
        .WithName("DeleteWidget2")
        .WithOpenApi();  
    }
	public static void MapWidget3Endpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Widget3").WithTags(nameof(Widget3));

        group.MapGet("/", () =>
        {
            return new [] { new Widget3() };
        })
        .WithName("GetAllWidget3s")
        .WithOpenApi();
        
        group.MapGet("/{id}", (int id) =>
        {
            //return new Widget3 { ID = id };
        })
        .WithName("GetWidget3ById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Widget3 input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateWidget3")
        .WithOpenApi();

        group.MapPost("/", (Widget3 model) =>
        {
            //return Results.Created($"/Widget3s/{model.ID}", model);
        })
        .WithName("CreateWidget3")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return Results.Ok(new Widget3 { ID = id });
        })
        .WithName("DeleteWidget3")
        .WithOpenApi();  
    }
}
