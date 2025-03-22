using BlazorApp.Core;
using BlazorApp.Services;
using BlazorApp1.Components;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7204/v1") });
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

ApplicationSettings applicationSetting = builder.Configuration.GetSection("AppSettings").Get<ApplicationSettings>();
builder.Services.AddSingleton(applicationSetting);

builder.Services.AddHttpClient();
builder.Services.AddMudServices();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(typeof(BlazorApp1.Client._Imports).Assembly)
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();
    

app.Run();
