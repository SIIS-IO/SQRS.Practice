using Microsoft.EntityFrameworkCore;
using MediatR;
using SQRS.Practice.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Implement Mediator*/
builder.Services.AddMediatR(typeof(Program).Assembly);

/*Implement DB In Memory*/
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TaskDb"));

var app = builder.Build();

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
