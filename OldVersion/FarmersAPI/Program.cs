using FarmersAPI.Models;
using FarmersAPI.Repositories;
using FarmersAPI.Repositories.Interfaces;
using FarmersAPI.Services;
using FarmersAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
builder.Services.AddScoped<IFarmerRepository,FarmerRepository>();
builder.Services.AddScoped<IFarmerService,FarmerService>();
builder.Services.AddScoped<IFilterHelperRepository<CollectionBillingDTO>,FilterHelperRepository<CollectionBillingDTO>>();
builder.Services.AddScoped<IFilterHelperService<CollectionBillingDTO>,FilterHelperService<CollectionBillingDTO>>();
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
app.UseCors(x => x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithHeaders()
                    .WithExposedHeaders(
                       new string[] {"X-Pagination"}
                    ));
app.UseAuthorization();

app.MapControllers();

app.Run();
