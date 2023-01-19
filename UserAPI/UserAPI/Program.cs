using Microsoft.EntityFrameworkCore;
using UserAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<UserAPIDbContext>(options => options.UseInMemoryDatabase("UsersDB"));

// adding service for mysql database
builder.Services.AddDbContext<UserAPIDbContext>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("userapidb"),
        ServerVersion.Parse("8.0.32-mysql"));
    });

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
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

app.UseRouting();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
