using Restaurants.Infrastructure.Extentions;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Application.Extentions;
using Serilog;
using Serilog.Events;
using Restaurants.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErrorHandlingMiddleware>();


builder.Services.AddInfrastruture(builder.Configuration);
builder.Services.AddApplication();
builder.Host.UseSerilog((context, configuration) =>

    configuration.ReadFrom.Configuration(context.Configuration)
    
);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
