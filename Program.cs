using Microsoft.EntityFrameworkCore;
using ClasificadorComents.Data;
using ClasificadorComents.Services;

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
// ✅ Solo esto para OpenAIService
builder.Services.AddSingleton<OpenAIService>();




var app = builder.Build();

// Permite archivos estáticos (como HTML, CSS, JS) desde wwwroot/
app.UseDefaultFiles(); // busca index.html, etc.
app.UseStaticFiles();

// Redirige raíz "/" a login.html directamente
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/paginas/login.html");
        return;
    }
    await next();
});

// Usa CORS (no problema si frontend y backend están juntos)
app.UseCors("PermitirFrontend");

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection(); // opcional en Render
}

app.UseAuthorization();
app.MapControllers();

app.Run();
