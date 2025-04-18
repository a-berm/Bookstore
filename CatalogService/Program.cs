using CatalogService.Clients;

var builder = WebApplication.CreateBuilder(args);

// HTTP clients for BookService and InventoryService
builder.Services.AddHttpClient<BookClient>(client =>
{
    client.BaseAddress = new Uri("http://bookservice");
});
builder.Services.AddHttpClient<InventoryClient>(client =>
{
    client.BaseAddress = new Uri("http://inventoryservice");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
