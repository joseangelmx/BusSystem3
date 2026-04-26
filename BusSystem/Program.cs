using BusSystem.ApplicationServices;
using BusSystem.ApplicationServices.Buses;
using BusSystem.ApplicationServices.Places;
using BusSystem.ApplicationServices.PricingSettings;
using BusSystem.ApplicationServices.Routes;
using BusSystem.ApplicationServices.SeatSettings;
using BusSystem.ApplicationServices.Tickets;
using BusSystem.ApplicationServices.Travels;
using BusSystem.Core.Buses;
using BusSystem.Core.Places;
using BusSystem.Core.PricingSettings;
using BusSystem.Core.SeatSettings;
using BusSystem.Core.Tickets;
using BusSystem.Core.Travels;
using BusSystem.DataAccess;
using BusSystem.DataAccess.Repositories;
using BusSystem.DataAccess.Repositories.Buses;
using BusSystem.DataAccess.Repositories.Places;
using BusSystem.DataAccess.Repositories.PricingSettings;
using BusSystem.DataAccess.Repositories.Routes;
using BusSystem.DataAccess.Repositories.SeatSettings;
using BusSystem.DataAccess.Repositories.Tickets;
using BusSystem.DataAccess.Repositories.Travels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;

// =====================
// DB CONTEXT
// =====================
builder.Services.AddDbContext<BusContext>(options =>
{
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(60),
                errorNumbersToAdd: null);
        });
});

// =====================
// AUTOMAPPER 
// =====================
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(MapperProfile).Assembly);
});
// =====================
// APPLICATION SERVICES
// =====================
builder.Services.AddTransient<ISeatSettingAppService, SeatSettingAppService>();
builder.Services.AddTransient<IBusAppService, BusAppService>();
builder.Services.AddTransient<IPlaceAppService, PlaceAppService>();
builder.Services.AddTransient<IRouteAppService, RouteAppService>();
builder.Services.AddTransient<ITravelsAppService, TravelsAppService>();
builder.Services.AddTransient<IPricingSettingAppService, PricingSettingAppService>();
builder.Services.AddTransient<ITicketAppService, TicketAppService>();
//builder.Services.AddTransient<IUserAppService, UserAppService>();

// =====================
// REPOSITORIES
// =====================
builder.Services.AddTransient<SeatSettingRepository>();
builder.Services.AddTransient<IRepository<int, SeatSetting>, SeatSettingRepository>();

builder.Services.AddTransient<BusRepository>();
builder.Services.AddTransient<IRepository<int, Bus>, BusRepository>();

builder.Services.AddTransient<PlaceRepository>();
builder.Services.AddTransient<IRepository<int, Place>, PlaceRepository>();

builder.Services.AddTransient<RouteRepository>();
builder.Services.AddTransient<IRepository<int, BusSystem.Core.Routes.Route>, RouteRepository>();

builder.Services.AddTransient<TravelRepository>();
builder.Services.AddTransient<IRepository<int, Travel>, TravelRepository>();

builder.Services.AddTransient<PricingSettingRepository>();
builder.Services.AddTransient<IRepository<int, PricingSetting>, PricingSettingRepository>();

builder.Services.AddTransient<TicketsRepository>();
builder.Services.AddTransient<IRepository<int, Ticket>, TicketsRepository>();
// =====================
// MVC / SWAGGER
// =====================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}