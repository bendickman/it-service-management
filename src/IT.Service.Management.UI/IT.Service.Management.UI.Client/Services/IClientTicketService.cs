using IT.Service.Management.UI.Shared.Models;

namespace IT.Service.Management.UI.Client.Services;

public interface IClientTicketService
{
    IObservable<IEnumerable<Ticket>> Tickets { get; }
}
