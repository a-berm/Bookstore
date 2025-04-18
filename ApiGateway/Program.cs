using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();
app.MapGet("/hello", () => "Hello World from .NET 8!");


app.MapReverseProxy();
app.Run();
