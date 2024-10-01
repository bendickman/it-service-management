using IT.Service.Management.Data.Context;
using IT.Service.Management.Data.Interfaces;
using IT.Service.Management.Data.Services;
using IT.Service.Management.Data.Settings;
using IT.Service.Management.UI.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMongoDB(mongoDBSettings.AtlasUri ?? "", mongoDBSettings.DatabaseName ?? ""));

builder.Services.AddScoped<ITicketService, TicketService>();

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
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(IT.Service.Management.UI.Client._Imports).Assembly);

app.Run();
