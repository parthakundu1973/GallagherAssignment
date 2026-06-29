using GallagherAssessment.API.Application.Decorator;
using GallagherAssessment.API.Application.DTOs;
using GallagherAssessment.API.Application.Service;
using GallagherAssessment.API.DomainLayer.Interfaces;
using GallagherAssessment.API.DomainLayer.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
///builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProbabilityCalculator, CombinedProbabilityCalculator>();
builder.Services.AddScoped<IProbabilityCalculator, EitherProbabilityCalculator>();
builder.Services.AddScoped<IProbabilityService, ProbabilityService>();
builder.Services.Decorate<IProbabilityService, LoggingProbabilityService>();

builder.Services.Configure<ProbabilityOperationChoiceItems>(
    builder.Configuration.GetSection("ProbabilityOperationChoiceItems"));

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "GallagherAssessment.API:";
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
//app.UseSerilogRequestLogging();
app.UseCors("AllowFrontend");
app.UseAuthorization();

app.MapControllers();

app.Run();
