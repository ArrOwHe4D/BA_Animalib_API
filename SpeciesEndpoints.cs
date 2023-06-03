using Microsoft.EntityFrameworkCore;
using AnimalibAPI.DataModels;
using Microsoft.AspNetCore.Http.HttpResults;
namespace AnimalibAPI;

public static class SpeciesEndpoints
{
    public static void MapSpeciesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Species").WithTags(nameof(Species));

        group.MapGet("/", async (AnimalibDbContext db) =>
        {
            return await db.Species.ToListAsync();
        })
        .WithName("GetAllSpecies")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Species>, NotFound>> (int id, AnimalibDbContext db) =>
        {
            return await db.Species.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Species model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSpeciesById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Species species, AnimalibDbContext db) =>
        {
            var affected = await db.Species
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(entity => entity.Id, species.Id)
                  .SetProperty(entity => entity.Name, species.Name)
                  .SetProperty(entity => entity.Type, species.Type)
                  .SetProperty(entity => entity.AnimalCount, species.AnimalCount)
                  .SetProperty(entity => entity.Image, species.Image)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSpecies")
        .WithOpenApi();

        group.MapPost("/", async (Species species, AnimalibDbContext db) =>
        {
            db.Species.Add(species);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Species/{species.Id}",species);
        })
        .WithName("CreateSpecies")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, AnimalibDbContext db) =>
        {
            var affected = await db.Species
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSpecies")
        .WithOpenApi();
    }
}
