using Ardalis.ApiEndpoints;
using IT.Service.Management.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IT.Service.Management.UI.Endpoints.Ticket.Delete;

[Route("v1/ticket")]
public class DeleteTicketEndpoint : EndpointBaseAsync.WithRequest<Guid>.WithActionResult
{
    private readonly ITicketService _ticketService;

    public DeleteTicketEndpoint(
        ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpDelete]
    [Route("{id}")]
    public override async Task<ActionResult> HandleAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await _ticketService
            .DeleteTicketAsync(id, cancellationToken);

        return new NoContentResult();
    }
}
