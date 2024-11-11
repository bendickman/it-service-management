using IT.Service.Management.UI.Shared.Clients;
using IT.Service.Management.UI.Shared.Models;

namespace IT.Service.Management.UI.Client.Services;

public class ClientTicketService : IClientTicketService
{
    private readonly ITicketClient _ticketClient;

    public ClientTicketService(
        ITicketClient ticketClient)
    {
        _ticketClient = ticketClient;
    }

    public async Task AddTicket(
        CreateTicketRequest request,
        CancellationToken cancellationToken = default)
    {
        await _ticketClient.AddTicket(request, cancellationToken);
    }

    public async Task UpdateTicket(
        UpdateTicketRequest request,
        CancellationToken cancellationToken = default)
    {
        await _ticketClient.UpdateTicket(request, cancellationToken);
    }

    public async Task DeleteTicketAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await _ticketClient.DeleteTicketAsync(id, cancellationToken);
    }

    public async Task<Ticket> GetTicketAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _ticketClient.GetTicketAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Ticket>> ListTicketsAsync(
        CancellationToken cancellationToken = default)
    {
        return await _ticketClient.GetTickets(cancellationToken);
    }
}
