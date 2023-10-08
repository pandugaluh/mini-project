using Project.Service.Course.Application;
using Project.Service.Course.Infrastructure;
using Project.Service.Course.Persistance;
using Project.Service.Course.Persistance.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplication(builder.Configuration);
builder.Services.ConfigureInfrastructure();
builder.Services.ConfigurePersistence(builder.Configuration);

var app = builder.Build();

DataMigration.Migration(app.Services);
DataSeeding.SeedData(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
