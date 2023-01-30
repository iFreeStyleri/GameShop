using GameShop.API.Core;
using GameShop.API.DAL;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .ServiceInit()
    .DataInit();

services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
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
