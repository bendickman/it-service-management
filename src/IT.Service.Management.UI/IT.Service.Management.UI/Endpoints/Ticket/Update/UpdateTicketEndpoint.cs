using Ardalis.ApiEndpoints;
using IT.Service.Management.Data.Interfaces;
using IT.Service.Management.UI.Shared.Clients;
using Microsoft.AspNetCore.Mvc;

namespace IT.Service.Management.UI.Endpoints.Ticket.Update;

[Route("v1/ticket")]
public class UpdateTicketEndpoint : EndpointBaseAsync.WithRequest<UpdateTicketRequest>.WithActionResult
{
    private readonly ITicketService _ticketService;

    public UpdateTicketEndpoint(
        ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPut]
    public override async Task<ActionResult> HandleAsync(
        [FromBody] UpdateTicketRequest request,
        CancellationToken cancellationToken = default)
    {
        var ticket = new Data.Models.Ticket
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
        };

        await _ticketService.UpdateTicketAsync(ticket, cancellationToken);

        return Ok();
    }
}
