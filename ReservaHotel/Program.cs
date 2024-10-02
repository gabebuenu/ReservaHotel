using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReservaHotel.Repositories;
using ReservaHotel.Repositories.Data;
using ReservaHotel.Services;

var builder = WebApplication.CreateBuilder(args);

// logging 
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Debug); 

AddServices(builder);

var app = builder.Build();

ConfigureMiddlewares(app);

app.Run();

void AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    builder.Services.AddAuthorization();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API ReservaHotel", Version = "v1" });
    });

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<HotelContext>(options =>
        options.UseSqlite(connectionString));

    builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
    builder.Services.AddScoped<ReservaService>();

    using var scope = builder.Services.BuildServiceProvider().CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<HotelContext>();

    SeedData.Initialize(context);
}

void ConfigureMiddlewares(WebApplication app)
{
    var logger = app.Logger;

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ReservaHotel v1");
            c.RoutePrefix = "swagger";  
        });
    }
    else
    {
        logger.LogInformation("Ambiente de produção. Desabilitando Swagger.");
    }

    logger.LogInformation("Habilitando Authorization.");
    app.UseAuthorization();

    logger.LogInformation("Mapeando controladores.");
    app.MapControllers();
}

