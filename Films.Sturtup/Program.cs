using Films.Core.Domain.Model;
//using Films.Core.Domain.Repositories;
using Films.Infrastructure.Database;
using Films.Sturtup;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program).Assembly);


builder.Services.AddDbContext<FilmDbContext>(config =>
    config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles(new DefaultFilesOptions()
{
    DefaultFileNames = new List<string>() { "index.html" }
});
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseRouting();
app.MapControllers();

app.Run();