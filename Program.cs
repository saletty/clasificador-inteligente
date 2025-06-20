using Microsoft.EntityFrameworkCore;
using ClasificadorComents.Data;

var builder = WebApplication.CreateBuilder(args);

// Obtiene el puerto asignado por Render
var port = Environment.GetEnvironmentVariable("PORT");

if (string.IsNullOrEmpty(port))
{
    port = "8080"; // puerto por defecto para desarrollo local
}

builder.WebHost.UseUrls($"http://*:{port}");

// Configurar la conexión MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// CORS: permite acceso desde el frontend desplegado (ajusta la URL)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("https://clasificador-inteligente.onrender.com") // reemplaza con tu URL frontend en Render
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();

app.UseCors("PermitirFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}
else
{
    // En producción evitamos redireccionar a HTTPS si Render ya lo maneja
    // app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
