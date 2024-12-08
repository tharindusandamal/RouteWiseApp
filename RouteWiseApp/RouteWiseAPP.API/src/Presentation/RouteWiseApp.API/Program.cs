using Microsoft.AspNetCore.Hosting;
using RouteWiseApp.API.Middlewares;
using RouteWiseApp.APPLICATION.Repositories;
using RouteWiseApp.APPLICATION.Services;
using RouteWiseApp.APPLICATION.UseCases;
using RouteWiseApp.DOMAIN.AppModels;
using RouteWiseApp.INFRASTRUCTURE.Repositories;
using RouteWiseApp.INFRASTRUCTURE.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject mock data
builder.Services.Configure<MockData>(builder.Configuration.GetSection("MockData"));

// Inject DI - Add services to the container
builder.Services.AddDependencies();

// Add mediator
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UseCaseBase).Assembly);
});

// Add logs - Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/api-log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure logs
app.UseSerilogRequestLogging();

// Use log middleware
app.UseMiddleware<LoggingMiddleware>();

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
