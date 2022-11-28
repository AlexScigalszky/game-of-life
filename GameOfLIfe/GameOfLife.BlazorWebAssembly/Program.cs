using GameOfLife.BlazorWebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<Engine.Implementations.GameOfLife>();
builder.Services.AddScoped<Engine.Implementations.RandomEnder>();
builder.Services.AddScoped<Engine.Implementations.ClassicGod>();
builder.Services.AddTransient((_) => new Engine.Implementations.SquareLand(20));
builder.Services.AddTransient((_) => new SquareLandReseatable(20));
builder.Services.AddScoped((_) => new HtmlObserver(20)); 


await builder.Build().RunAsync();
