using medium_refresh_token_api.DataAccess.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option =>
{
    option.AddPolicy("allowedOrigin",
                       builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                       );
});

// database
string connectionStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allowedOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
