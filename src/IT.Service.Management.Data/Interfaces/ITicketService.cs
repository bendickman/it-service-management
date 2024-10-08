using IT.Service.Management.Data.Models;

namespace IT.Service.Management.Data.Interfaces;

public interface ITicketService
{
    IEnumerable<Ticket> GetAllTickets();

    Ticket? GetTicket(Guid id);

    void AddTicket(Ticket ticket);
}
