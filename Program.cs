using Microsoft.EntityFrameworkCore;
using ClasificadorComents.Data;// el namespace donde está AppDbContext

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

builder.Environment.EnvironmentName = "Development";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseStaticFiles(); // Esta línea es necesaria para servir archivos .html

// Redirigir la raíz "/" a "/paginas/login.html"
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/paginas/login.html");
        return;
    }
    await next();
});
// Usar CORS
app.UseCors("PermitirFrontend");

// Configurar middleware condicionalmente
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection(); // Solo en desarrollo
}
else
{
    // app.UseHttpsRedirection(); ← evitamos esto para no romperlo en Render
    // En producción (ej. Docker en Render), no se redirige manualmente a HTTPS
}
app.UseAuthorization();

app.MapControllers(); // Para la API backend

app.Run();

