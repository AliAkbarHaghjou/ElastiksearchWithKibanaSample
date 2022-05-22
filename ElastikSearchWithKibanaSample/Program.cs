using ElastikSearchWithKibanaSample.Context;
using ElastikSearchWithKibanaSample.Interfaces;
using ElastikSearchWithKibanaSample.Middlewares;
using ElastikSearchWithKibanaSample.Repository;
using ElastikSearchWithKibanaSample.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
});

builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<ITodoService, TodoService>();


var app = builder.Build();

app.ConfigureCustomExceptionMiddleware();

app.UseRouting();
app.MapControllers();

app.Run();
