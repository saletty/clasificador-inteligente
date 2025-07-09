using Microsoft.EntityFrameworkCore;
using ClasificadorComents.Data;

var builder = WebApplication.CreateBuilder(args);

// Detecta el puerto dinámico que Render asigna
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// Conexión a la base de datos MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// CORS (permite solicitudes del mismo dominio)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// ✅ CORS siempre debe estar antes de todo lo que pueda manejar rutas
app.UseCors("PermitirFrontend");

// ✅ Archivos estáticos
app.UseDefaultFiles();
app.UseStaticFiles();

// ✅ Redirección raíz (si es necesaria)
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/paginas/login.html");
        return;
    }
    await next();
});

// ✅ Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Puedes dejar esto si Render lo necesita, pero puede omitirse localmente:
    // app.UseHttpsRedirection(); 
}

app.UseAuthorization();
app.MapControllers();
app.Run();




