using MiVideoEditor.Server.Services;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios a tu contenedor de inyección de dependencias (DI).
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Aquí inyectamos nuestro servicio de procesamiento de video.
// Scoped significa que se crea una nueva instancia por cada solicitud.
builder.Services.AddScoped<VideoProcessingService>();

var app = builder.Build();

// Configura el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // La app usa HSTS en producción
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
