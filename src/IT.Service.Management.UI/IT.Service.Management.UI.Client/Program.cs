using IT.Service.Management.UI.Client.Services;
using IT.Service.Management.UI.Shared.Clients;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services
    .AddRefitClient<ITicketClient>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
