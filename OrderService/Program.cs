using MassTransit;
using OrderService.Clients;
using OrderService.Consumers;
using OrderService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IOrderService, OrderService.Services.OrderService>();
builder.Services.AddHttpClient<BookClient>(client =>
{
    client.BaseAddress = new Uri("http://bookservice"); // Docker/K8s DNS name
});
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<StockReservedConsumer>();
    x.AddConsumer<StockNotAvailableConsumer>();
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("admin");
            h.Password("admin");
        });

        cfg.ConfigureEndpoints(ctx);
    });
});

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
