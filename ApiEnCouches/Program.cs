using ApiEnCouches.DataAccess;
using ApiEnCouches.DataAccess.DataAccess;
using ApiEnCouches.DataAccess.IDataAccess;
using ApiEnCouches.DataAccess.Seed;
using ApiEnCouches.Service.IService;
using ApiEnCouches.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<ISlotService, SlotService>();
builder.Services.AddScoped<IRoomDataAccess, RoomDataAccess>();
builder.Services.AddScoped<ISlotDataAccess, SlotDataAccess>();
builder.Services.AddScoped<ISeeder, RoomSeeder>();
builder.Services.AddScoped<DbSeeder>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
    var isProduction = app.Environment.IsProduction();

    // Applique toutes les migrations manquantes
    db.Database.Migrate();
    await seeder.Execute(db, isProduction);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
