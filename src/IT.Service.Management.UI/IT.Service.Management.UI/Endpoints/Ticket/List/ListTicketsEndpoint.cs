using Ardalis.ApiEndpoints;
using IT.Service.Management.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IT.Service.Management.UI.Endpoints.Ticket.List;

[Route("v1/tickets")]
public class ListTicketsEndpoint : EndpointBaseAsync.WithRequest<ListTicketsRequest>.WithActionResult
{
    private readonly ITicketService _ticketService;

    public ListTicketsEndpoint(
        ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public override async Task<ActionResult> HandleAsync(
        [FromQuery] ListTicketsRequest request,
        CancellationToken cancellationToken = default)
    {
        var tickets = _ticketService.GetAllTickets();

        return Ok(tickets);
    }
}
