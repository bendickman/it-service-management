using Ardalis.ApiEndpoints;
using IT.Service.Management.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IT.Service.Management.UI.Endpoints.Ticket.Get;

[Route("/v1/ticket/{id:guid}")]
public class GetTicketEndpoint : EndpointBaseAsync.WithRequest<Guid>.WithActionResult
{
    private readonly ITicketService _ticketService;

    public GetTicketEndpoint(
        ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public override async Task<ActionResult> HandleAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var ticket = await _ticketService.GetTicketAsync(id);

        if (ticket is null)
        {
            return NotFound(id);
        }

        return Ok(ticket);
    }
}
