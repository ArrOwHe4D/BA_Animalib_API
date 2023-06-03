using Microsoft.EntityFrameworkCore;
using AnimalibAPI.DataModels;
using Microsoft.AspNetCore.Http.HttpResults;
namespace AnimalibAPI;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Animals").WithTags(nameof(Animal));

        group.MapGet("/", async (AnimalibDbContext db) =>
        {            
            return await db.Animals.ToListAsync();
        })
        .WithName("GetAllAnimals")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Animal>, NotFound>> (int id, AnimalibDbContext db) =>
        {
            return await db.Animals.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Animal model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAnimalById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Animal animal, AnimalibDbContext db) =>
        {
            var affected = await db.Animals
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(entity => entity.Id, animal.Id)
                  .SetProperty(entity => entity.Name, animal.Name)
                  .SetProperty(entity => entity.Height, animal.Height)
                  .SetProperty(entity => entity.Weight, animal.Weight)
                  .SetProperty(entity => entity.Regions, animal.Regions)
                  .SetProperty(entity => entity.Species, animal.Species)
                  .SetProperty(entity => entity.Description, animal.Description)
                  .SetProperty(entity => entity.Image, animal.Image)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAnimal")
        .WithOpenApi();

        group.MapPost("/", async (Animal animal, AnimalibDbContext db) =>
        {
            db.Animals.Add(animal);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Animal/{animal.Id}",animal);
        })
        .WithName("CreateAnimal")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, AnimalibDbContext db) =>
        {
            var affected = await db.Animals
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAnimal")
        .WithOpenApi();
    }
}
