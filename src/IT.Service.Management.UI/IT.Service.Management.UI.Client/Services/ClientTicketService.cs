using IT.Service.Management.UI.Shared.Clients;
using IT.Service.Management.UI.Shared.Models;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace IT.Service.Management.UI.Client.Services;

public class ClientTicketService : IClientTicketService
{
    private readonly BehaviorSubject<IEnumerable<Ticket>> _ticketsSubject = new BehaviorSubject<IEnumerable<Ticket>>(Enumerable.Empty<Ticket>());
    private readonly ITicketClient _ticketClient;

    public IObservable<IEnumerable<Ticket>> Tickets => _ticketsSubject.AsObservable();

    public ClientTicketService(
        ITicketClient ticketClient)
    {
        _ticketClient = ticketClient;

        Observable
            .FromAsync(() => _ticketClient.GetTickets(default))
            .Subscribe((tickets) => _ticketsSubject.OnNext(tickets));
    }
}
