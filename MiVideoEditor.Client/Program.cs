using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MiVideoEditor.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configura el componente raíz de tu aplicación.
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configura HttpClient para que sepa dónde está el backend.
// En un proyecto alojado (Hosted Blazor), la base es la misma URL.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
