using Events.Controllers;
using Events.Data;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<EventDataInterface, EventData>();
builder.Services.AddLogging();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Events", Version = "v1" });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseExceptionHandler("/Home/Error");
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Events");
});
app.Run();
