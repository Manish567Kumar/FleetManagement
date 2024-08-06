using Microsoft.EntityFrameworkCore;
using FleetManagement.Models;
using FleetManagement.Interfaces;
using FleetManagement.Services;
using static FleetManagement.Services.VehicleService;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FleetManagement");

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
builder.Services.AddDbContext<FleetManagementContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
{
    builder.WithOrigins("https://localhost:7004", "http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
}));
builder.Services.AddControllers();
builder.Services.AddScoped<VehicleService>();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
//builder.Services.AddControllersWithViews();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.Run();


