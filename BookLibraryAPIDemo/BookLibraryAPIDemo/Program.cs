using BookLibraryAPIDemo.API.Extensions;
using BookLibraryAPIDemo.Application.Commands.BookLibraryAPICategory;
using BookLibraryAPIDemo.Application.Interfaces;
using BookLibraryAPIDemo.Application.Mapping;
using BookLibraryAPIDemo.Application.Services;
using BookLibraryAPIDemo.Infrastructure.Context;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using BookLibraryAPIDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NLog;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// NLog configuration
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BookLibraryContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
        b => b.MigrationsAssembly("Bookstore.API"));
});
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblyContaining(typeof(CreateCategory)));
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.ConfigureCors();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.MapControllers();

app.Run();
