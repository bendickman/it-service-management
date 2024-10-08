using IT.Service.Management.UI.Shared.Models;

namespace IT.Service.Management.UI.Client.Services;

public interface IClientTicketService
{
    Task<IEnumerable<Ticket>> ListTicketsAsync(CancellationToken cancellationToken = default);

    Task<Ticket> GetTicketAsync(Guid id, CancellationToken cancellationToken = default);
}
