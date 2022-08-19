using HttpPatchExample.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;
using HttpPatchExample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDB"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

InitializeDb();
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

static void InitializeDb()
{
    var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase("AppDB", b => b.EnableNullChecks(false))
        .Options;
    using var context = new AppDbContext(dbOptions);
    var people = new List<Person>
    {
        new() { FirstName = "Iman", LastName = "Safari", IsActive = true},
        new() { FirstName = "Ali", LastName = "Joshaghani", IsActive = false },
        new()
        {
            FirstName = "Zlatan", LastName = "Ibrahimovic", IsActive = true
        }

    };

    context.Persons.AddRange(people);
    context.SaveChanges();
}