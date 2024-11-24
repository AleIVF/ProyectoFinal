using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Components;
using ProyectoFinal.Models;
using ProyectoFinal.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Add DbContext
builder.Services.AddDbContext<AgendaDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepositorioPacientes, RepositorioPacientes>();

builder.Services.AddScoped<IRepositorioDoctores, RepositorioDoctores>();

builder.Services.AddScoped<IRepositorioCitas, RepositorioCitas>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
