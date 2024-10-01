using IT.Service.Management.UI.Shared.Models;
using Refit;

namespace IT.Service.Management.UI.Shared.Clients;

public interface ITicketClient
{
    [Get("/v1/tickets")]
    Task<IEnumerable<Ticket>> GetTickets(CancellationToken cancellationToken);
}
