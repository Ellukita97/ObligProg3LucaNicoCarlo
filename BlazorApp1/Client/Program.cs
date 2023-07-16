using BlazorApp1.Client;
using BlazorApp1.Client.Extenciones;
using BlazorApp1.Client.Services;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;




var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient();
builder.Services.AddSingleton<PeliculasService>();
builder.Services.AddSingleton<GenerosService>();
builder.Services.AddSingleton<ProyeccionesService>();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AutentificacionExtencion>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
