using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Commands;
using ProductService.Application.Handlers;
using ProductService.Domain.Repositories;
using ProductService.Infraestructure.Messaging;
using ProductService.Infraestructure.Persistence;
using ProductService.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ProductContext>(
    options => options.UseInMemoryDatabase("ProductService"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ProductMessageListener>();

var app = builder.Build();

var mediator = app.Services.CreateScope().ServiceProvider.GetRequiredService<IMediator>();
var listener = new ProductMessageListener(mediator);
listener.StartListening();
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
