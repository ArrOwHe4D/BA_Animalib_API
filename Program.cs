using AnimalibAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AnimalibDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AnimalibConnection") ?? throw new InvalidOperationException()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapAnimalEndpoints();
app.MapRegionEndpoints();
app.MapSpeciesEndpoints();

app.Run();
