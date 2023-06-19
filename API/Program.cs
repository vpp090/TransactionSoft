using System.Text.Json.Serialization;
using API.Common;
using Hangfire;
using Infrastructure.Data;
using Hangfire.SQLite;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString(Constants.DefaultConnection));
});

builder.Services.AddProjectServices();

var options = new SQLiteStorageOptions();
builder.Services.AddHangfire(configuration => configuration
        .UseSQLiteStorage("Filename=transactionsoft.db;", options));

builder.Services.AddHangfireServer();

builder.Services.AddCors(options => 
{
    options.AddPolicy(name: "AppCors",
    policy => {
        policy.WithOrigins("https://localhost:4200", "http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("AppCors");

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();
app.MapHangfireDashboard();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<DataContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
}
catch(Exception ex) 
{
    logger.LogError(ex, "Error occurred during migration");
    throw;
}

app.Run();
