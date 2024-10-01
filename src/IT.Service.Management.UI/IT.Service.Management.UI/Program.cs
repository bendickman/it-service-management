using IT.Service.Management.Data.Context;
using IT.Service.Management.Data.Interfaces;
using IT.Service.Management.Data.Services;
using IT.Service.Management.Data.Settings;
using IT.Service.Management.UI.Client.Services;
using IT.Service.Management.UI.Components;
using IT.Service.Management.UI.Shared.Clients;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMongoDB(mongoDBSettings.AtlasUri ?? "", mongoDBSettings.DatabaseName ?? ""));

builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IClientTicketService, ClientTicketService>();

builder.Services
    .AddRefitClient<ITicketClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7243/"));

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

app.MapControllers();

app.Run();
