using System.Text.Json;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Global.DTOs;
using Global.Service;

using Blazored.SessionStorage;
using Blazored.LocalStorage;

// using Calidad.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();
// builder.Services.AddBlazoredSessionStorage(config =>
// {
//     config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
//     config.JsonSerializerOptions.IgnoreNullValues = true;
//     config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
//     config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//     config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//     config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
//     config.JsonSerializerOptions.WriteIndented = false;
// });


builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddOptions();  
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<global::Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider,global:: Global.Service.Autenticacion.CustomAuthStateProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
