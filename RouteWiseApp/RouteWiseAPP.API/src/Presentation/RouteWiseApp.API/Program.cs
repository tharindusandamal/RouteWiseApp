using Microsoft.AspNetCore.Hosting;
using RouteWiseApp.APPLICATION.Repositories;
using RouteWiseApp.APPLICATION.Services;
using RouteWiseApp.APPLICATION.UseCases;
using RouteWiseApp.DOMAIN.AppModels;
using RouteWiseApp.INFRASTRUCTURE.Repositories;
using RouteWiseApp.INFRASTRUCTURE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject mock data
builder.Services.Configure<MockData>(builder.Configuration.GetSection("MockData"));

// Inject DI
builder.Services.AddScoped<INodeRepository, NodeRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<INodePathFinder, NodePathFinder>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UseCaseBase).Assembly);
});

var app = builder.Build();

// Apply a global, default CORS policy
app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
});

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
