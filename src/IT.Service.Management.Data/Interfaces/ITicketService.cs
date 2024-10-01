using IT.Service.Management.Data.Models;
using MongoDB.Bson;

namespace IT.Service.Management.Data.Interfaces;

public interface ITicketService
{
    IEnumerable<Ticket> GetAllTickets();

    Ticket? GetTicket(ObjectId id);

    void AddTicket(Ticket ticket);
}
