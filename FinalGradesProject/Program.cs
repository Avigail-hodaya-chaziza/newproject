
using FinalGradesProject;
using Microsoft.Extensions.Configuration;
using FinalGradesProject.Configuration;
using FinalGradesProject.Services;
using FinalGradesProject.controllers; 
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddSingleton<IStudents, Students>();
builder.Services.AddSingleton<IGradeManager, GradeManager>();
builder.Services.AddSingleton<IPasswordManager, PasswordManager>();
builder.Services.Configure<Percent>(builder.Configuration.GetSection("Percent"));
builder.Services.Configure<Password>(builder.Configuration.GetSection("Teacher"));
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");
app.Run();

