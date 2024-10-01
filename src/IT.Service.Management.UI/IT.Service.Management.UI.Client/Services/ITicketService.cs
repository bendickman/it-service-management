using IT.Service.Management.UI.Shared.Models;

namespace IT.Service.Management.UI.Client.Services;

public interface ITicketService
{
    IObservable<IEnumerable<Ticket>> Tickets { get; }
}
