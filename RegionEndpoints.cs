using Microsoft.EntityFrameworkCore;
using AnimalibAPI.DataModels;
using Microsoft.AspNetCore.Http.HttpResults;
namespace AnimalibAPI;

public static class RegionEndpoints
{
    public static void MapRegionEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Regions").WithTags(nameof(Region));

        group.MapGet("/", async (AnimalibDbContext db) =>
        {
            return await db.Regions.ToListAsync();
        })
        .WithName("GetAllRegions")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Region>, NotFound>> (int id, AnimalibDbContext db) =>
        {
            return await db.Regions.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Region model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetRegionById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Region region, AnimalibDbContext db) =>
        {
            var affected = await db.Regions
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(entity => entity.Id, region.Id)
                  .SetProperty(entity => entity.Name, region.Name)
                  .SetProperty(entity => entity.Size, region.Size)
                  .SetProperty(entity => entity.SpeciesCount, region.SpeciesCount)
                  .SetProperty(entity => entity.Image, region.Image)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateRegion")
        .WithOpenApi();

        group.MapPost("/", async (Region region, AnimalibDbContext db) =>
        {
            db.Regions.Add(region);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Region/{region.Id}",region);
        })
        .WithName("CreateRegion")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, AnimalibDbContext db) =>
        {
            var affected = await db.Regions
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteRegion")
        .WithOpenApi();
    }
}
