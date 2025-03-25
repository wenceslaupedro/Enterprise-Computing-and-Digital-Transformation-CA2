using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WorkoutContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

