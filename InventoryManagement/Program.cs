using Entitites;
using InventoryManagement.Startup_Configuration;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDBservices(builder.Configuration);

var app = builder.Build();
//await app.ApplyMigrationsAsync()
app.MapControllers();
app.UseRouting();
app.MapGet("/", () => "Hello World!");

app.Run();

