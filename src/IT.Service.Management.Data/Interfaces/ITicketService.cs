using IT.Service.Management.Data.Models;

namespace IT.Service.Management.Data.Interfaces;

public interface ITicketService
{
    IEnumerable<Ticket> GetAllTickets();

    Task<Ticket?> GetTicketAsync(Guid id);

    Task AddTicketAsync(
        Ticket ticket,
        CancellationToken cancellationToken);

    Task DeleteTicketAsync(Guid id, CancellationToken cancellationToken = default);
}
