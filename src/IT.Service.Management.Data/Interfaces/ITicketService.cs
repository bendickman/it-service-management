using IT.Service.Management.Data.Models;

namespace IT.Service.Management.Data.Interfaces;

public interface ITicketService
{
    IEnumerable<Ticket> GetAllTickets();

    Task<Ticket?> GetTicketAsync(Guid id);

    void AddTicket(Ticket ticket);
}
