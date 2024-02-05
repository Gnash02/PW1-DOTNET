using System.Configuration;
using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;
using WebApi_PW1.Repositories;

//using WebApi_PW1.Models.Person;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PersonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"),builder=>builder.EnableRetryOnFailure(5,TimeSpan.FromSeconds(10), null)));
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddScoped<IPersonRepository, PersonRepository>();


var app = builder.Build();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();