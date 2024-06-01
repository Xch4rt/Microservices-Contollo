using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
// Add services to the container.

builder.Services.AddControllers();

builder.Configuration.SetBasePath(env.ContentRootPath).AddJsonFile($"ocelot.{env.EnvironmentName}.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

await app.UseOcelot();

app.Run();
