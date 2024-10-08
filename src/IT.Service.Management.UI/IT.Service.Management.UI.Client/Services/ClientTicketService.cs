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

    public async Task<IEnumerable<Ticket>> ListTicketsAsync(
        CancellationToken cancellationToken = default)
    {
        return await _ticketClient.GetTickets(cancellationToken);
    }
}
