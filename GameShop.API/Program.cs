using GameShop.API.Core;
using GameShop.API.Core.Abstractions.Repositories;
using GameShop.API.DAL;
using GameShop.API.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .ServiceInit()
    .DataInit();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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
