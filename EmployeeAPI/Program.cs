using EmployeeAPI.Repositories;
using EmployeeAPI.Repositories.Contexts;
using EmployeeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeContext>(
    (options) =>
        options
            .UseMySQL(builder.Configuration.GetConnectionString("mysql")!)
            .LogTo(Console.WriteLine, LogLevel.Trace)
            .EnableSensitiveDataLogging()
);
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
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
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("X-Pagination"));
app.UseAuthorization();

app.MapControllers();

app.Run();
