using ElastikSearchWithKibanaSample.Context;
using ElastikSearchWithKibanaSample.Interfaces;
using ElastikSearchWithKibanaSample.Middlewares;
using ElastikSearchWithKibanaSample.Repository;
using ElastikSearchWithKibanaSample.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .WriteTo.Console()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
    {
        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
        AutoRegisterTemplate = true,
        NumberOfShards = 2,
        NumberOfReplicas = 1
    })
    .Enrich.WithProperty("Envirement", context.HostingEnvironment.EnvironmentName)
    .ReadFrom.Configuration(context.Configuration);
});

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
